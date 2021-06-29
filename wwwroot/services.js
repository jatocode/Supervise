const api_url = 'http://localhost:5000/Supervise'
async function getServices() {
    var resp = await fetch(api_url);
    var json = await resp.json();

    return json;
}

async function drawTable(services) {
    console.log(services);

    let table = document.createElement('table');
    services.forEach(service => {
        let row = table.insertRow();
        // var idcell = row.insertCell();
        var buttonCell = row.insertCell();
        var namecell = row.insertCell();
        var statuscell = row.insertCell();

        let button = document.createElement('button');
        button.innerHTML = 'Restart';
        button.onclick = () => {
            restartService(service.id);
        }
        buttonCell.append(button);

        //idcell.append(document.createTextNode(service.id));
        namecell.append(document.createTextNode(service.name));
        statuscell.append(document.createTextNode(statusToString(service.status)));
    });

    document.getElementById('services').append(table);
}

async function services() {
    var services = await getServices();
    drawTable(services);
}

async function restartService(id) {
    console.log(`Restarting ${id}`);
    let data = {};
    data.id = id;
    const response = await fetch(api_url + `/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });
    return response.json();
}

function statusToString(status) {
    switch (status) {
        case 0: return 'STOPPED';
        case 1: return 'RUNNING';
        case 2: return 'STARTING';
        case 3: return 'STOPPING';
    }
    return 'UNKNOWN';
}