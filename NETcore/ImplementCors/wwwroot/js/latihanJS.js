////$(document).ready(function () {
////    $.ajax({
////        url: "https://swapi.dev/api/people/"
////    }).done((result) => {
////        console.log(result);

////        var text = "";
////        $.each(result.results, function (key, val) {
////            /*text += `<li>${val.name}</li>`*/
////            text += `<tr id="result${key + 1}">
////            <td>${key + 1}</td>
////            <td>${val.name}</td>
////            <td><button type ="button" class="btn btn-primary" data-toggle ="modal" data-target="#exampleModal${key + 1}">Detail
////                </button>
////                <button class="click${key + 1} btn btn-danger">Delete</button>
////                 <div class= "modal fade" id="exampleModal${key + 1}" tabindex="-1" aria-labelledby="exampleModal${key + 1}Label" aria-hidden="true">
////                 <div class="modal-dialog">
////                 <div class="modal-content">
////                    <div class="modal-header">
////                        <h5 class="modal-title" id="#exampleModal${key + 1}Label">Detail of ${val.name}</h5>
////                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
////                            <span aria-label="true">&times;</span>
////                        </button>
////                    </div>

////                <div class="modal-body">
////                    <ul>
////                        <li>Gender : ${val.gender}</li>
////                        <li>Height: ${val.height}</li>
////                        <li>Hair Color: ${val.hair_color}</li>
////                        <li>Homeworld : ${val.homeworld}</li>
////                        <li>mass : ${val.mass}</li>
////                        <li>Skin Color : ${val.skin_color}</li>
////                    </ul>
////                </div>
////                <div class="modal-footer">
////                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
////                        Close
////                    </button>
////                </div>
////              </div>
////            </div>

////            </div>

////            </td>
////            </tr>`;
////            $(`.click${key + 1}`).click(function () {
////                let isDelete = confirm(`Delete ${val.name}`);
////                if (isDelete) {
////                    var el = document.getElementById(`result${key + 1}`);
////                    el.remove();
////                }
////            });


////        });


////        $('#starwars').html(text);

////    }).fail((result) => {
////        console.log(result);
////    });


////});
$(document).ready(function () {
    $.ajax({
        url: "https://pokeapi.co/api/v2/pokemon/"
    }).done((result) => {
        console.log(result);
        var text = "";
        $.each(result.results, function (key, val) {
            /*text += `<li>${val.name}</li>`*/
            text += `<tr id="result${key + 1}">
            <td>${key + 1}</td>
            <td>${val.name}</td>
            <td><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" onclick ="detail('${val.url}')">Detail</button>
            </tr>`;

            //$(document).ready(function () {

            //    $(`.click${key + 1}`).click(function (){
            //        let isDelete = confirm(`Delete ${val.name}?`);
            //        if (isDelete) {
            //            var el = document.getElementById(`result${key + 1}`);
            //            el.remove();
            //        }
            //    });
            //});


        });


        $('#starwars').html(text);

    }).fail((result) => {
        console.log(result);
    });

});
function detail(url) {
    $.ajax({
        url: url
    }).done((result) => {
        console.log(result);
        var text = "";
        var img = "";
        var type = "";
        var ability = "";
        console.log(result.sprites.other.dream_world.front_default);
        title = `<h1>${result.forms[0].name}</h1>`;
        img = `<img src="${result.sprites.other.dream_world.front_default}" class="rounded mx-auto d-block">`;

        for (let i = 0; i < result.types.length; i++) {
            if (result.types[i].type.name == 'grass') {
                type += `
                    <span class="badge badge-success">Grass</span>;`

            } if (result.types[i].type.name == 'poison') {
                type += `
                    <span class="badge badge-dark">Poison</span>`;
            } if (result.types[i].type.name == 'fire') {
                type += `
                    <span class="badge badge-danger">Fire</span>`;
            } if (result.types[i].type.name == 'flying') {
                type += `
                    <span class="badge badge-warning">Flying</span>`;
            } if (result.types[i].type.name == 'water') {
                type += `
                    <span class="badge badge-primary">Water</span>`;
            } if (result.types[i].type.name == 'bug') {
                type += `
                    <span class="badge badge-secondary">Bug</span>`;
            } if (result.types[i].type.name == 'normal') {
                type += `
                    <span class="badge badge-light">Normal</span>`;
            }
        }

text = `
      
               <ul>
                <li>ID      : ${result.id}</li>
                <li>Name    : ${result.forms[0].name}</li>
                <li>Weight  : ${result.weight}</li>
                <li>EXP     : ${result.base_experience}</li>
                `;

for (let j = 0; j < result.abilities.length; j++) {
    if (j == 0) {
        ability += `<li>Ability : 
               <ol>
                <li>${result.abilities[0].ability.name}</li>`;
    } else if (j == result.abilities.length - 1) {
        ability += `
                <li>${result.abilities[j].ability.name}</li>
                </ol>
               </ul>`;
    } else {
        ability += `<li>${result.abilities[j].ability.name}</li>`
    }
}

$("#StarWars").modal('show');


$(".modal-body").html(title + img + type + text + ability + status);

    }).fail((result) => {
    console.log(result);
});
}
