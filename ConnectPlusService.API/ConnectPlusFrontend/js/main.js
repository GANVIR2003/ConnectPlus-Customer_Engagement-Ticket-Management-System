function hideAll() {
    document.getElementById("dashboardSection").classList.add("d-none");
    document.getElementById("raiseTicketSection").classList.add("d-none");
    document.getElementById("ticketsSection").classList.add("d-none");
    document.getElementById("customersSection").classList.add("d-none");
}
let currentRole = "Agent";

function setRole(role) {
    currentRole = role;
    applyRoleAccess();
}

function applyRoleAccess() {

    const dashboardBtn = document.querySelector('button[onclick="showDashboard()"]');
    const raiseBtn = document.querySelector('button[onclick="showRaiseTicket()"]');
    const ticketsBtn = document.querySelector('button[onclick="showTickets()"]');
    const customersBtn = document.querySelector('button[onclick="showCustomers()"]');

    // Reset all buttons
    dashboardBtn.style.display = "block";
    raiseBtn.style.display = "block";
    ticketsBtn.style.display = "block";
    customersBtn.style.display = "block";

    if (currentRole === "Agent") {
        customersBtn.style.display = "none";
    }

    if (currentRole === "Supervisor") {
        raiseBtn.style.display = "none";
    }

    if (currentRole === "Admin") {
        // Admin sees everything
    }

    showDashboard();
}

applyRoleAccess();