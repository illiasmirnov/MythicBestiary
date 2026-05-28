/* ======================================================
   APPLICATION INITIALIZATION
====================================================== */

document.addEventListener("DOMContentLoaded", () => {
    initializeNavigation();

    initializeForms();

    initializeCreatureGallery();

    initializeSearch();

    initializeFilters();

    initializeThemeSwitcher();

    initializeDeleteConfirmation();

    initializeScrollEffects();

    initializeLazyLoading();
});

/* ======================================================
   NAVIGATION
====================================================== */

function initializeNavigation() {
    const navigationToggle = document.querySelector("[data-navigation-toggle]");
    const navigationMenu = document.querySelector("[data-navigation-menu]");
    const navigationLinks = document.querySelectorAll(".navigation a");

    if (navigationToggle && navigationMenu) {
        navigationToggle.addEventListener("click", () => {
            navigationMenu.classList.toggle("navigation--open");
            navigationToggle.classList.toggle("navigation-toggle--active");
        });
    }

    const currentPath = window.location.pathname.toLowerCase();

    navigationLinks.forEach(link => {
        const href = link.getAttribute("href");

        if (!href) {
            return;
        }

        const normalizedHref = href.toLowerCase();

        if (
            normalizedHref === currentPath ||
            (normalizedHref !== "/" && currentPath.startsWith(normalizedHref))
        ) {
            link.classList.add("active");
        }

        link.addEventListener("click", () => {
            if (navigationMenu) {
                navigationMenu.classList.remove("navigation--open");
            }
        });
    });
}

/* ======================================================
   FORMS
====================================================== */

function initializeForms() {
    const forms = document.querySelectorAll("form");

    forms.forEach(form => {
        form.addEventListener("submit", event => {
            clearValidationMessages(form);

            const requiredFields = form.querySelectorAll("[required]");

            let isValid = true;

            requiredFields.forEach(field => {
                const value = field.value.trim();

                if (!value) {
                    isValid = false;

                    showValidationMessage(
                        field,
                        "Поле є обов'язковим для заповнення."
                    );
                }
            });

            if (!isValid) {
                event.preventDefault();
            }
        });

        const controls = form.querySelectorAll(".form-control");

        controls.forEach(control => {
            control.addEventListener("input", () => {
                removeValidationMessage(control);
            });
        });

        initializeAutosave(form);
    });
}

function clearValidationMessages(form) {
    const messages = form.querySelectorAll(".validation-message");

    messages.forEach(message => {
        message.remove();
    });
}

function showValidationMessage(field, message) {
    removeValidationMessage(field);

    const validationMessage = document.createElement("div");

    validationMessage.className = "validation-message";
    validationMessage.textContent = message;

    field.classList.add("input-validation-error");

    field.parentElement.appendChild(validationMessage);
}

function removeValidationMessage(field) {
    field.classList.remove("input-validation-error");

    const validationMessage =
        field.parentElement.querySelector(".validation-message");

    if (validationMessage) {
        validationMessage.remove();
    }
}

function initializeAutosave(form) {
    const autosaveKey = `mythic-bestiary-autosave-${window.location.pathname}`;

    const controls = form.querySelectorAll(
        "input, textarea, select"
    );

    const savedData = localStorage.getItem(autosaveKey);

    if (savedData) {
        try {
            const parsedData = JSON.parse(savedData);

            controls.forEach(control => {
                if (
                    control.name &&
                    parsedData[control.name] !== undefined &&
                    !control.value
                ) {
                    control.value = parsedData[control.name];
                }
            });
        } catch (error) {
            console.error("Autosave restore error:", error);
        }
    }

    controls.forEach(control => {
        control.addEventListener("input", () => {
            const formData = {};

            controls.forEach(item => {
                if (item.name) {
                    formData[item.name] = item.value;
                }
            });

            localStorage.setItem(
                autosaveKey,
                JSON.stringify(formData)
            );
        });
    });

    form.addEventListener("submit", () => {
        localStorage.removeItem(autosaveKey);
    });
}

/* ======================================================
   CREATURE GALLERY
====================================================== */

function initializeCreatureGallery() {
    const galleryImages = document.querySelectorAll(
        ".creature-gallery img"
    );

    const previewImage = document.querySelector(
        "[data-gallery-preview]"
    );

    galleryImages.forEach(image => {
        image.addEventListener("click", () => {
            if (previewImage) {
                previewImage.src = image.src;
                previewImage.alt = image.alt;
            }

            galleryImages.forEach(item => {
                item.classList.remove("active");
            });

            image.classList.add("active");
        });

        image.addEventListener("dblclick", () => {
            openFullscreenImage(image.src, image.alt);
        });
    });
}

function openFullscreenImage(source, altText) {
    const overlay = document.createElement("div");

    overlay.className = "gallery-fullscreen";

    overlay.innerHTML = `
        <div class="gallery-fullscreen__content">
            <img src="${source}" alt="${altText}">
        </div>
    `;

    overlay.addEventListener("click", () => {
        overlay.remove();
    });

    document.body.appendChild(overlay);
}

/* ======================================================
   SEARCH
====================================================== */

function initializeSearch() {
    const searchInput = document.querySelector(
        "[data-creature-search]"
    );

    const creatureCards = document.querySelectorAll(
        ".creature-card"
    );

    if (!searchInput || creatureCards.length === 0) {
        return;
    }

    const debouncedSearch = debounce(() => {
        const query = searchInput.value
            .trim()
            .toLowerCase();

        creatureCards.forEach(card => {
            const searchableContent =
                card.textContent.toLowerCase();

            const isVisible =
                searchableContent.includes(query);

            card.style.display = isVisible ? "" : "none";
        });
    }, 250);

    searchInput.addEventListener("input", debouncedSearch);
}

/* ======================================================
   FILTERS
====================================================== */

function initializeFilters() {
    const filterSelects = document.querySelectorAll(
        "[data-filter]"
    );

    const creatureCards = document.querySelectorAll(
        ".creature-card"
    );

    if (filterSelects.length === 0 || creatureCards.length === 0) {
        return;
    }

    filterSelects.forEach(filter => {
        filter.addEventListener("change", () => {
            applyFilters(creatureCards, filterSelects);
        });
    });
}

function applyFilters(cards, filters) {
    cards.forEach(card => {
        let isVisible = true;

        filters.forEach(filter => {
            const filterKey = filter.dataset.filter;
            const filterValue = filter.value
                .trim()
                .toLowerCase();

            if (!filterValue) {
                return;
            }

            const cardValue =
                card.dataset[filterKey];

            if (
                !cardValue ||
                !cardValue.toLowerCase().includes(filterValue)
            ) {
                isVisible = false;
            }
        });

        card.style.display = isVisible ? "" : "none";
    });
}

/* ======================================================
   THEME SWITCHER
====================================================== */

function initializeThemeSwitcher() {
    const themeToggle = document.querySelector(
        "[data-theme-toggle]"
    );

    const root = document.documentElement;

    const savedTheme =
        localStorage.getItem("mythic-bestiary-theme");

    if (savedTheme) {
        root.setAttribute("data-theme", savedTheme);
    }

    if (!themeToggle) {
        return;
    }

    themeToggle.addEventListener("click", () => {
        const currentTheme =
            root.getAttribute("data-theme");

        const nextTheme =
            currentTheme === "dark"
                ? "light"
                : "dark";

        root.setAttribute("data-theme", nextTheme);

        localStorage.setItem(
            "mythic-bestiary-theme",
            nextTheme
        );
    });
}

/* ======================================================
   DELETE CONFIRMATION
====================================================== */

function initializeDeleteConfirmation() {
    const deleteForms = document.querySelectorAll(
        "[data-delete-form]"
    );

    deleteForms.forEach(form => {
        form.addEventListener("submit", event => {
            const confirmation = confirm(
                "Ви впевнені, що бажаєте видалити цю істоту?"
            );

            if (!confirmation) {
                event.preventDefault();
            }
        });
    });
}

/* ======================================================
   SCROLL EFFECTS
====================================================== */

function initializeScrollEffects() {
    const animatedElements = document.querySelectorAll(
        ".creature-card, .creature-details"
    );

    if (animatedElements.length === 0) {
        return;
    }

    const observer = new IntersectionObserver(
        entries => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add("visible");
                }
            });
        },
        {
            threshold: 0.15
        }
    );

    animatedElements.forEach(element => {
        observer.observe(element);
    });
}

/* ======================================================
   LAZY LOADING
====================================================== */

function initializeLazyLoading() {
    const lazyImages = document.querySelectorAll(
        "img[data-src]"
    );

    if (lazyImages.length === 0) {
        return;
    }

    const imageObserver = new IntersectionObserver(
        entries => {
            entries.forEach(entry => {
                if (!entry.isIntersecting) {
                    return;
                }

                const image = entry.target;

                image.src = image.dataset.src;

                image.removeAttribute("data-src");

                imageObserver.unobserve(image);
            });
        }
    );

    lazyImages.forEach(image => {
        imageObserver.observe(image);
    });
}

/* ======================================================
   API HELPERS
====================================================== */

async function fetchData(url) {
    try {
        const response = await fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });

        if (!response.ok) {
            throw new Error(
                `HTTP error: ${response.status}`
            );
        }

        return await response.json();
    } catch (error) {
        console.error("Fetch error:", error);

        return null;
    }
}

/* ======================================================
   UTILITIES
====================================================== */

function debounce(callback, delay = 300) {
    let timeoutId;

    return (...args) => {
        clearTimeout(timeoutId);

        timeoutId = setTimeout(() => {
            callback(...args);
        }, delay);
    };
}

/* ======================================================
   FUTURE FEATURES
====================================================== */

// TODO:
// Добавить notifications system

// TODO:
// Добавить client-side caching

// TODO:
// Добавить offline support