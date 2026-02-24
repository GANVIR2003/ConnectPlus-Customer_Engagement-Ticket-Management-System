function showCustomers() {
    hideAll();
    document.getElementById("customersSection").classList.remove("d-none");

    fetch(`${BASE_URL}/Customers`)
        .then(res => res.json())
        .then(data => {

            let rows = data.map(c => `
                <tr>
                    <td>${c.customerId}</td>
                    <td>${c.fullName}</td>
                    <td>${c.email}</td>
                </tr>
            `).join("");

            document.getElementById("customersSection").innerHTML = `
                <h3>Customers</h3>
                <div class="card p-3 shadow">
                    <table class="table table-hover">
                        <thead class="table-dark">
                            <tr>
                                <th>ID</th>
                                <th>Name</th>
                                <th>Email</th>
                            </tr>
                        </thead>
                        <tbody>
                            ${rows}
                        </tbody>
                    </table>
                </div>
            `;
        });
}