

document.getElementById("form").addEventListener("submit", evt => {
    evt.preventDefault();
    GetGrid();
});

document.getElementById("hue-input").addEventListener("input", evt => {
    SetColorOfTextBox();
});

document.getElementById("sat-input").addEventListener("input", evt => {
    SetColorOfTextBox();
});


async function GetGrid() {

    try {
        ShowSpinner();
        let gridArea = document.getElementById("gridarea");
        gridArea.innerHTML = ""; //clean up area
        let size = document.getElementById("size").value;
        let rangeTo = document.getElementById("rangeTo").value;
        let rangeFrom = document.getElementById("rangeFrom").value;
        if (parseInt(rangeFrom) >= parseInt(rangeTo)) {
            alert("RangeTo has to be biger than RangeFrom");
            return;
        }

        let url = `/grid?size=${size}&rangefrom=${rangeFrom}&rangeto=${rangeTo}`;
        let response = await fetch(url, { method: 'POST' });

        let data = await response.json();
        console.log(data);

        data.forEach(box => {
            let element = document.createElement("div");
            element.className = "single-grid";
            element.innerText = box.number;
            var hue = document.getElementById("hue-input").value;
            var sat = document.getElementById("sat-input").value;
            element.style.backgroundColor = `hsl(${hue}, ${sat}%, ${box.lightness}%)`
            if (box.lightness < 10) {
                element.style.color = "white";
            }
            gridArea.appendChild(element);
        });


    }
    catch (ex) {
        console.error(ex);

    }
    finally {
        HideSpinner();
    }
}

function ShowSpinner() {
    document.getElementById("spinner").classList.remove("hidden");
}

function HideSpinner() {
    document.getElementById("spinner").classList.add("hidden");
}

function SetColorOfTextBox() {
    var hue = document.getElementById("hue-input").value;
    var sat = document.getElementById("sat-input").value;

    document.getElementById("test-color").style.backgroundColor = `hsl(${hue}, ${sat}%, 50%)`;
}