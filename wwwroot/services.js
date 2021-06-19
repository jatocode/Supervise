async function getServices() {
    var resp = await fetch('http://localhost:5000/Supervise');
    var json = await resp.json();

    return json;
}

async function drawTable(services) {
    console.log(services);

    let table = document.createElement('table');
    services.forEach(service => {
        let row = table.insertRow();
        var idcell = row.insertCell();
        var namecell = row.insertCell();
        var statuscell = row.insertCell();

        idcell.append(document.createTextNode(service.id));
        namecell.append(document.createTextNode(service.name));
        statuscell.append(document.createTextNode(service.status));
    });

    document.getElementById('services').append(table);
}

async function services() {
    var services = await getServices();
    drawTable(services);
}