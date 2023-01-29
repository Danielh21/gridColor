
GetGrid();

async function GetGrid() {
    let url = '/grid';
    let response = await fetch(url, { method: 'POST'});

    let data = await response.json(); // read response body and parse as JSON

    console.log(data);
}