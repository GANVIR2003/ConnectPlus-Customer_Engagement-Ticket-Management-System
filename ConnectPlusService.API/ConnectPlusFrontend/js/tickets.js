function showTickets() {
    hideAll();
    document.getElementById("ticketsSection").classList.remove("d-none");

    fetch(`${BASE_URL}/Tickets`)
        .then(res => res.json())
        .then(data => {

            let rows = data.map(t => `
                <tr>
                    <td>${t.ticketId}</td>
                    <td>${t.title}</td>
                    <td>${t.status}</td>
                    <td>${t.priority}</td>
                </tr>
            `).join("");

            document.getElementById("ticketsSection").innerHTML = `
                <h3>Manage Tickets</h3>
                <div class="card p-3 shadow">
                    <table class="table table-hover">
                        <thead class="table-dark">
                            <tr>
                                <th>ID</th>
                                <th>Title</th>
                                <th>Status</th>
                                <th>Priority</th>
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