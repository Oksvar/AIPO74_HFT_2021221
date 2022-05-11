let staff = [];
let connection = null;

let staffIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5555/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("LaboratoryStaffCreated", (user, message) => {
        getdata();
    });
    connection.on("LaboratoryStaffUpdated", (user, message) => {
        getdata();
    });
    connection.on("LaboratoryStaffDeleted", (user, message) => {
        getdata();
    });
    

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function getdata() {
    fetch('http://localhost:5555/laboratorystaff')
        .then(x => x.json())
        .then(y => {
            staff = y
            display();
        });
}

function display() {
    document.getElementById('updateformdiv').style.display = 'none';
    document.getElementById('resultarea').innerHTML = '';
    staff.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.staffID + "</td><td>" + t.fullName + "</td><td>" + t.position + "</td><td>" + t.accessLevel + "</td><td>" + t.yearExpirience + "</td><td>" + `<button type="button" onclick="remove(${t.staffID})">Delete</button>` + `<button type="button" onclick="showupdate(${t.staffID})">Edit</button>` + "</td></tr>";
        console.log(t.fullName)
    });
}

function showupdate(id) {
    document.getElementById('staffpositiontoupdate').value = staff.find(t => t['staffID'] == id)['position'];
    document.getElementById('updateformdiv').style.display = 'flex';
    staffIdToUpdate = id;
}
//Update is not working
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let pos = document.getElementById('staffpositiontoupdate').value;
    fetch('http://localhost:5555/laboratorystaff', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { staffID: staffIdToUpdate, position: pos, })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('fullName').value;
    let posi = document.getElementById('position').value;
    let acess = document.getElementById('accessLevel').value;
    let year = document.getElementById('yearExpirience').value;
    fetch('http://localhost:5555/laboratorystaff', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { fullName: name, position: posi, accessLevel: acess, yearExpirience: year })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:5555/laboratorystaff/' + id, {
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