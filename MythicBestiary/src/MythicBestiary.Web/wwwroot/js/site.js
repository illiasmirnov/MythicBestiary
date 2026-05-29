/* ======================================================
   ІНІЦІАЛІЗАЦІЯ ЗАСТОСУНКУ
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
   НАВІГАЦІЯ
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
            navigationMenu?.classList.remove("navigation--open");
            navigationToggle?.classList.remove("navigation-toggle--active");
        });
    });
}

/* ======================================================
   ФОРМИ
====================================================== */

function initializeForms() {
    const forms = document.querySelectorAll("form");

    forms.forEach(form => {
        form.addEventListener("submit", event => {
            clearValidationMessages(form);

            const requiredFields = form.querySelectorAll("[required]");
            let isValid = true;

            requiredFields.forEach(field => {
                if (!("value" in field)) {
                    return;
                }

                const value = String(field.value).trim();

                if (!value) {
                    isValid = false;
                    showValidationMessage(field, "Це поле є обов’язковим.");
                }
            });

            if (!isValid) {
                event.preventDefault();
            }
        });

        form.querySelectorAll(".form-control").forEach(control => {
            control.addEventListener("input", () => {
                removeValidationMessage(control);
            });
        });

        initializeAutosave(form);
    });
}

function clearValidationMessages(form) {
    form.querySelectorAll(".validation-message").forEach(message => {
        message.remove();
    });
}

function showValidationMessage(field, message) {
    removeValidationMessage(field);

    const validationMessage = document.createElement("div");
    validationMessage.className = "validation-message";
    validationMessage.textContent = message;

    field.classList.add("input-validation-error");
    field.parentElement?.appendChild(validationMessage);
}

function removeValidationMessage(field) {
    field.classList.remove("input-validation-error");

    const validationMessage =
        field.parentElement?.querySelector(".validation-message");

    validationMessage?.remove();
}

function initializeAutosave(form) {
    const autosaveKey = `mythic-bestiary-autosave-${window.location.pathname}`;
    const controls = form.querySelectorAll("input, textarea, select");

    try {
        const savedData = localStorage.getItem(autosaveKey);

        if (savedData) {
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
        }
    } catch (error) {
        console.warn("Не вдалося відновити автозбережені дані форми.", error);
    }

    controls.forEach(control => {
        control.addEventListener("input", () => {
            const formData = {};

            controls.forEach(item => {
                if (item.name) {
                    formData[item.name] = item.value;
                }
            });

            try {
                localStorage.setItem(autosaveKey, JSON.stringify(formData));
            } catch (error) {
                console.warn("Не вдалося зберегти дані форми.", error);
            }
        });
    });

    form.addEventListener("submit", () => {
        localStorage.removeItem(autosaveKey);
    });
}

/* ======================================================
   ГАЛЕРЕЯ ІСТОТ
====================================================== */

function initializeCreatureGallery() {
    const galleryImages = document.querySelectorAll(".creature-gallery img");
    const previewImage = document.querySelector("[data-gallery-preview]");

    galleryImages.forEach(image => {
        image.addEventListener("click", () => {
            if (previewImage) {
                previewImage.src = image.src;
                previewImage.alt = image.alt || "Зображення істоти";
            }

            galleryImages.forEach(item => item.classList.remove("active"));
            image.classList.add("active");
        });

        image.addEventListener("dblclick", () => {
            openFullscreenImage(image.src, image.alt || "Зображення істоти");
        });
    });
}

function openFullscreenImage(source, altText) {
    const overlay = document.createElement("div");
    overlay.className = "gallery-fullscreen";

    const content = document.createElement("div");
    content.className = "gallery-fullscreen__content";

    const image = document.createElement("img");
    image.src = source;
    image.alt = altText;

    content.appendChild(image);
    overlay.appendChild(content);

    overlay.addEventListener("click", () => {
        overlay.remove();
    });

    document.body.appendChild(overlay);
}

/* ======================================================
   ПОШУК
====================================================== */

function initializeSearch() {
    const searchInput = document.querySelector("[data-creature-search]");
    const creatureCards = document.querySelectorAll(".creature-card");

    if (!searchInput || creatureCards.length === 0) {
        return;
    }

    const debouncedSearch = debounce(() => {
        const query = searchInput.value.trim().toLowerCase();

        creatureCards.forEach(card => {
            const searchableContent = card.textContent.toLowerCase();
            card.style.display = searchableContent.includes(query) ? "" : "none";
        });
    }, 250);

    searchInput.addEventListener("input", debouncedSearch);
}

/* ======================================================
   ФІЛЬТРИ
====================================================== */

function initializeFilters() {
    const filterSelects = document.querySelectorAll("[data-filter]");
    const creatureCards = document.querySelectorAll(".creature-card");

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
            const filterValue = filter.value.trim().toLowerCase();

            if (!filterValue) {
                return;
            }

            const cardValue = card.dataset[filterKey];

            if (!cardValue || !cardValue.toLowerCase().includes(filterValue)) {
                isVisible = false;
            }
        });

        card.style.display = isVisible ? "" : "none";
    });
}

/* ======================================================
   ПЕРЕМИКАЧ ТЕМИ
====================================================== */

function initializeThemeSwitcher() {
    const themeToggle = document.querySelector("[data-theme-toggle]");
    const root = document.documentElement;

    const savedTheme = localStorage.getItem("mythic-bestiary-theme");

    if (savedTheme) {
        root.setAttribute("data-theme", savedTheme);
    }

    if (!themeToggle) {
        return;
    }

    themeToggle.addEventListener("click", () => {
        const currentTheme = root.getAttribute("data-theme");
        const nextTheme = currentTheme === "dark" ? "light" : "dark";

        root.setAttribute("data-theme", nextTheme);
        localStorage.setItem("mythic-bestiary-theme", nextTheme);
    });
}

/* ======================================================
   ПІДТВЕРДЖЕННЯ ВИДАЛЕННЯ
====================================================== */

function initializeDeleteConfirmation() {
    const deleteForms = document.querySelectorAll("[data-delete-form]");

    deleteForms.forEach(form => {
        form.addEventListener("submit", event => {
            const confirmation = confirm(
                "Ви впевнені, що хочете видалити цю істоту?"
            );

            if (!confirmation) {
                event.preventDefault();
            }
        });
    });
}

/* ======================================================
   АНІМАЦІЇ ПІД ЧАС ПРОКРУЧУВАННЯ
====================================================== */

function initializeScrollEffects() {
    const animatedElements = document.querySelectorAll(
        ".creature-card, .creature-details"
    );

    if (animatedElements.length === 0 || !("IntersectionObserver" in window)) {
        animatedElements.forEach(element => element.classList.add("visible"));
        return;
    }

    const observer = new IntersectionObserver(
        entries => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add("visible");
                    observer.unobserve(entry.target);
                }
            });
        },
        { threshold: 0.15 }
    );

    animatedElements.forEach(element => observer.observe(element));
}

/* ======================================================
   ЛІНИВЕ ЗАВАНТАЖЕННЯ ЗОБРАЖЕНЬ
====================================================== */

function initializeLazyLoading() {
    const lazyImages = document.querySelectorAll("img[data-src]");

    if (lazyImages.length === 0) {
        return;
    }

    if (!("IntersectionObserver" in window)) {
        lazyImages.forEach(image => loadLazyImage(image));
        return;
    }

    const imageObserver = new IntersectionObserver(entries => {
        entries.forEach(entry => {
            if (!entry.isIntersecting) {
                return;
            }

            loadLazyImage(entry.target);
            imageObserver.unobserve(entry.target);
        });
    });

    lazyImages.forEach(image => imageObserver.observe(image));
}

function loadLazyImage(image) {
    image.src = image.dataset.src;
    image.removeAttribute("data-src");
}

/* ======================================================
   API-ДОПОМІЖНІ ФУНКЦІЇ
====================================================== */

async function fetchData(url) {
    try {
        const response = await fetch(url, {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        });

        if (!response.ok) {
            throw new Error(`Помилка HTTP: ${response.status}`);
        }

        return await response.json();
    } catch (error) {
        console.error("Не вдалося отримати дані:", error);
        return null;
    }
}

/* ======================================================
   УТИЛІТИ
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
   ЗАПЛАНОВАНІ ПОКРАЩЕННЯ
====================================================== */

// TODO: додати систему сповіщень.
// TODO: додати клієнтське кешування.
// TODO: додати підтримку офлайн-режиму.