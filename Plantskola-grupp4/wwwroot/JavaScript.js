
  items.forEach(item => list.appendChild(item));

function toggleDropdown(event) {
    event.stopPropagation(); // Stoppar klick från att bubbla upp

    const dropdown = document.getElementById("seasonDropdown");
    const arrow = document.getElementById("dropdownArrow");

    const isOpen = dropdown.style.display === "block";

    // Stäng alla dropdowns (ifall du lägger till fler i framtiden)
    closeDropdowns();

    if (!isOpen) {
        dropdown.style.display = "block";
        arrow.textContent = "▴"; // Pil uppåt
    }
}

// Funktion som stänger alla dropdowns
function closeDropdowns() {
    document.getElementById("seasonDropdown").style.display = "none";
    document.getElementById("dropdownArrow").textContent = "▾"; // Pil neråt
}

// Stäng dropdown vid klick ANYWHERE på sidan
document.addEventListener("click", function () {
    closeDropdowns();
});

