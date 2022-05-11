let cust = [];
let connection = null;

let custIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5555/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CustomerCreated", (user, message) => {
        getdata();
    });
    connection.on("CustomerDeleted", (user, message) => {
        getdata();
    });
    connection.on("CustomerUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function getdata() {
    fetch('http://localhost:5555/customer')
        .then(x => x.json())
        .then(y => {
            cust = y
            console.log(cust);
            display();
        });
}

function display() {
    document.getElementById('updateformdiv').style.display = 'none';
    document.getElementById('resultarea').innerHTML = '';
    cust.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.customerID + "</td><td>" + t.name + "</td><td>" + t.address + "</td><td>" + t.phone + "</td><td>" + t.city + "</td><td>" + t.country + "</td><td>" + t.secrecyStamp + "</td><td>" + `<button type="button" onclick="remove(${t.customerID})">Delete</button>` + `<button type="button" onclick="showupdate(${t.customerID})">Edit</button>` + "</td></tr>";
        console.log(t.name)
    });
}

function showupdate(id) {
    document.getElementById('customeraddresstoupdate').value = cust.find(t => t['customerID'] == id)['address'];
    document.getElementById('updateformdiv').style.display = 'flex';
    custIdToUpdate = id;
}
//Is not working update
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let docer = document.getElementById('customeraddresstoupdate').value;
    fetch('http://localhost:5555/customer', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { customerID: custIdToUpdate, address: docer })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let ame = document.getElementById('name').value;
    let hone = document.getElementById('phone').value;
    let ddress = document.getElementById('address').value;
    let cit = document.getElementById('city').value;
    let counte = document.getElementById('country').value;
    let secstamp = document.getElementById('secrecyStamp').value;
    fetch('http://localhost:5555/customer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: ame, phone: hone, address: ddress, city: cit, country: counte, secrecyStamp: secstamp })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:5555/customer/' + id, {
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