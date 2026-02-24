function showRaiseTicket() {
    hideAll();
    document.getElementById("raiseTicketSection").classList.remove("d-none");

    document.getElementById("raiseTicketSection").innerHTML = `
        <div class="card p-4 shadow">
            <h4>Raise New Ticket</h4>

            <div class="mb-3">
                <label>Customer Name</label>
                <input type="text" id="custName" class="form-control">
            </div>

            <div class="mb-3">
                <label>Email</label>
                <input type="email" id="custEmail" class="form-control">
            </div>

            <div class="mb-3">
                <label>Issue Title</label>
                <input type="text" id="titleInput" class="form-control">
            </div>

            <div class="mb-3">
                <label>Description</label>
                <textarea id="descInput" class="form-control"></textarea>
            </div>

            <div class="mb-3">
                <label>Priority</label>
                <select id="priorityInput" class="form-select">
                    <option>Low</option>
                    <option>Medium</option>
                    <option>High</option>
                </select>
            </div>

            <button class="btn btn-primary" onclick="createCustomerAndTicket()">Submit</button>
        </div>
    `;
}

function createCustomerAndTicket() {

    const name = document.getElementById("custName").value;
    const email = document.getElementById("custEmail").value;
    const title = document.getElementById("titleInput").value;
    const description = document.getElementById("descInput").value;
    const priority = document.getElementById("priorityInput").value;

    if (!name || !email || !title) {
        alert("All required fields must be filled");
        return;
    }

    // Step 1: Create Customer
    fetch(`${BASE_URL}/Customers`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            fullName: name,
            email: email,
            phoneNumber: "N/A"
        })
    })
    .then(res => {
    if (!res.ok) {
        return res.text().then(text => { throw new Error(text); });
    }
    return res.json();
})
    .then(customer => {

        // Step 2: Create Ticket linked to new customer
        return fetch(`${BASE_URL}/Tickets`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                title: title,
                description: description,
                priority: priority,
                customerId: customer.customerId,
                agentId: 1,
                categoryId: 1
            })
        });

    })
    .then(response => {
        if (!response.ok) {
            return response.text().then(text => { throw new Error(text); });
        }
        alert("Ticket Created Successfully");
        showDashboard();
    })
    .catch(error => {
        alert(error.message);
    });
}