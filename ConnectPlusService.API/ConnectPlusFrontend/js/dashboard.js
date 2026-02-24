function showDashboard() {
    hideAll();
    document.getElementById("dashboardSection").classList.remove("d-none");

    fetch(`${BASE_URL}/Dashboard`)
        .then(res => res.json())
        .then(data => {

            document.getElementById("dashboardSection").innerHTML = `
                <h3 class="mb-4">Service Dashboard</h3>
                <div class="row">
                    <div class="col-md-3">
                        <div class="card bg-primary text-white p-3 shadow">
                            <h6>Total Tickets</h6>
                            <h2>${data.totalTickets}</h2>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="card bg-warning text-white p-3 shadow">
                            <h6>Open Tickets</h6>
                            <h2>${data.openTickets}</h2>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="card bg-success text-white p-3 shadow">
                            <h6>Closed Tickets</h6>
                            <h2>${data.closedTickets}</h2>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="card bg-danger text-white p-3 shadow">
                            <h6>SLA Breached</h6>
                            <h2>${data.slaBreachedTickets}</h2>
                        </div>
                    </div>
                    <div class="col-md-3">
    <div class="card bg-info text-white p-3 shadow">
        <h6>Avg Resolution (hrs)</h6>
        <h2>${data.averageResolutionHours.toFixed(2)}</h2>
    </div>
</div>
                </div>
            `;
        });
}