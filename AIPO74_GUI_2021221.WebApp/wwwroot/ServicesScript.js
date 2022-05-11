let serv = [];
let connection = null;

let servIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5555/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ServicesCreated", (user, message) => {
        getdata();
    });
    connection.on("ServicesUpdated", (user, message) => {
        getdata();
    });
    connection.on("ServicesDeleted", (user, message) => {
        getdata();
    });


    connection.onclose(async () => {
        await start();
    });
    start();
}

async function getdata() {
    fetch('http://localhost:5555/services')
        .then(x => x.json())
        .then(y => {
            serv = y
            display();
        });
}

function display() {
    document.getElementById('updateformdiv').style.display = 'none';
    document.getElementById('resultarea').innerHTML = '';
    serv.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.serviceId + "</td><td>" + t.name + "</td><td>" + t.price + "</td><td>" + t.developmentTime + "</td><td>" + t.dangerous + "</td><td>" + `<button type="button" onclick="remove(${t.serviceId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.serviceId})">Edit</button>` + "</td></tr>";
        console.log(t.fullName)
    });
}

function showupdate(id) {
    document.getElementById('servicestoupdate').value = serv.find(t => t['serviceId'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    servIdToUpdate = id;
}
//Change is not working
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let pos = document.getElementById('servicestoupdate').value;
    fetch('http://localhost:5555/services', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { serviceId: servIdToUpdate, name: pos, })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('name').value;
    let posi = document.getElementById('price').value;
    let acess = document.getElementById('developmentTime').value;
    let year = document.getElementById('dangerous').value;
    fetch('http://localhost:5555/services', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, price: posi, developmentTime: acess, dangerous: year })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:5555/services/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); alert("This instance is connected to something else in the database, first you should delete them as well") });
}