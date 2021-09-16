/*/*const { Button } = require("bootstrap");*/


$(document).ready(function () {
    var table = $('#datatable').DataTable({
        "filter": true,
        "ajax": {
            "url": "https://localhost:44396/API/Persons/GetRegisterVM",
            "datatype": "json",
            "dataSrc": "result"
        },
        "columns": [
            {
                "data": "namaLengkap"

            },
            {
                "data": "nik",
                "autoWidth": true
            },
            {
                "data": "email",
                "autoWidth": true
            },
            {
                "data": "universityId",
                "autoWidth": true
            },
            //{
            //    "data": "universityId",
            //    "render": function (data, type, row) {
            //        if (row[`universityId`] = (`1`)) {
            //            return row = IT - PLN
            //        }

            //        else {
            //            return row = Telkom
            //        }
             
                    
            //    }
            
            //    },
            //    "autoWidth": true
            //},
            {
                "data": "gpa",
                "autoWidth": true
            },
            {
                "data": "phoneNumber",
                "render": function (data, type, row) {
                    if (row[`phoneNumber`].startsWith(`0`)) {
                        return`+62${row[`phoneNumber`].substr(1)}`
                    }
                    return `+62${row[`phoneNumber`]}`
                },
                "authoWidth": true
            },
            //{
            //    "data": "salary",
            //    "autoWidth": true
            //},
            {
                "data": null,
                "render": function (data, type, row) {

                    return "RP."+ row["salary"];
                },
                "autoWidth": true
            },
            {
                "data": "gender",
                "autoWidth": true
            },
            {
                "data":null,
                "render": function (data, type, row) {
                    return `<button type ="button"
                            class="btn btn-primary"
                            data-toggle ="modal"
                            data-target="#exampleModal"
                            onclick="detail('${row["nik"]}')">Detail</button></td>`;
                
                },
               
                 "orderable": false
            }
        ]
    });
    //$("#btnSubmit").click(e => {

    //    e.preventDefault();
    //    const nik = $('#NIK').val();
    //    const phoneNumber = $('#phone').val();
    //    const firstName = $('#firstName').val();
    //    const lastName = $('#lastName').val();
    //    const birthDate = $('#birthDate').val();
    //    const gender = $('#Gender').val();
    //    const salary = $('#salary').val();
    //    const email = $('#email').val();
    //    const password = $('#password').val();
    //    const degree = $('#degree').val();
    //    const gpa = $('#gpa').val();
    //    const role = $('#Role').val();
    //    const universityId = $('#univ').val();

    //    var data = {
    //        "NIK": nik,
    //        "FirstName": firstName,
    //        "LastName": lastName,
    //        "phoneNumber": phoneNumber,
    //        "BirthDate": birthDate,
    //        "Salary": salary,
    //        "Email": email,
    //        "Gender": parseInt(gender),
    //        "Password": password,
    //        "UniversityId": parseInt(universityId),
    //        "Degree": degree,
    //        "GPA": gpa,
    //        "RoleId": parseInt(roleId)
    //    };

    //    console.log(data);
    //    // post data to database
    //    data = JSON.stringify(data);
    //    insert(data)
    //    //idmodal di hide
    //    $('#form').modal('hide');



    //    //reload only datatable
    //    setInterval(function () {
    //        table.ajax.reload(null, false); // user paging is not reset on reload
    //    }, 0);

    //});
});

(function () {
    'use strict';
    window.addEventListener('load', function () {

        var forms = this.document.getElementsByClassName('needs-validation');

        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === true) {
                    event.preventDefault();
                    var obj = {
                        "NIK": nik,
                        "FirstName": firstName,
                        "LastName": lastName,
                        "phoneNumber": phoneNumber,
                        "BirthDate": birthDate,
                        "Salary": salary,
                        "Email": email,
                        "Gender": parseInt(gender),
                        "Password": password,
                        "UniversityId": parseInt(universityId),
                        "Degree": degree,
                        "GPA": gpa,
                        "RoleId": parseInt(roleId)
                    };
                    console.log(data);
                    // post data to database
                    data = JSON.stringify(data);
                    insert(data)
                    //idmodal di hide
                    $('#form').modal('hide');
                    //reload only datatable
                    setInterval(function () {
                        table.ajax.reload(null, false); // user paging is not reset on reload
                    }, 0);
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

function detail(nik) {
    $.ajax({
        url: "https://localhost:44396/API/Persons/GetRegister/"+nik
    }).done((result) => {
        console.log(result)
        console.log(nik);
        //menampil kan data
        var text = "";


        text = `<ul>
                      <li><b>Full Name   : </b>${result.result.namaLengkap}</li>
                        <li><b>NIK         :</b> ${result.result.nik}</li>
                        <li><b>Email       : </b>${result.result.email}</li>
                        <li><b>University  : </b>${result.result.universityId}</li>

                        <li><b>GPA       : </b>${result.result.gpa}</li>
                        <li><b>Phone Number: </b>${result.result.phoneNumber}</li>
                        <li><b>Salary      : </b>${result.result.salary}</li>
                           <li><b>Gender      : </b>${result.result.gender}</li>
                        <li><b>Degree      : </b>${result.result.degree}</li>
                           <li><b>RoleId      : </b>${result.result.roleId}</li>
                </ul>`
        $("#exampleModalLabel,modal-title").html(detail);
        title = `<h5>Detail of ${result.result.namaLengkap}</h5>`;
            ;
        //$("#dataModal").modal('show');
        $("#data").html(text);
    }).fail((result) => {
        console.log(result);
    });
   
};




function insert(data) {
    console.log(data);
    $.ajax({
        url: "https://localhost:44396/API/Persons/Register/",
        method: 'POST',
        dataType: 'json',
        contentType: 'application/json',
        data: data
    }).done((result) => {
        //buat alert pemberitahuan jika 
        alert('SUCCESS')
    }).fail((error) => {
        //alert pemberitahuan jika gagal
        alert('ERROR')

    });
}

//$(document).ready(function () {
//    $.ajax({
//        url: "https://localhost:44396/API/Persons/GetRegisterVM/"
//    }).done((result) => {
//        console.log(result);

//        var text = "";
//        $.each(result.result, function (key, val) {
//            /*text += `<li>${val.name}</li>`*/
//            text += `<tr id="result${key + 1}">
//            <td>${key + 1}</td>
//            <td>${val.namaLengkap}</td>
//            <td><button type ="button" class="btn btn-primary" data-toggle ="modal" data-target="#exampleModal${key + 1}">Detail
//                </button>
//                <button class="click${key + 1} btn btn-danger">Delete</button>
//                 <div class= "modal fade" id="exampleModal${key + 1}" tabindex="-1" aria-labelledby="exampleModal${key + 1}Label" aria-hidden="true">
//                 <div class="modal-dialog">
//                 <div class="modal-content">
//                    <div class="modal-header">
//                        <h5 class="modal-title" id="#exampleModal${key + 1}Label">Detail of ${val.name}</h5>
//                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
//                            <span aria-label="true">&times;</span>
//                        </button>
//                    </div>

//                <div class="modal-body">
                   
//                    <ul>
//                       <li><b>Full Name   : </b>${val.namaLengkap}</li>
////                        <li><b>NIK         :</b> ${val.nik}</li>
////                        <li><b>Email       : </b>${val.email}</li>
////                        <li><b>GPA       : </b>${val.gpa}</li>
////                        <li><b>Phone Number: </b>${val.phoneNumber}</li>                                        
////                        <li><b>Salary      : </b>${val.salary}</li>
////                        <li><b>Degree      : </b>${val.degree}</li>
//                    </ul>
                
//                  </div>
//                <div class="modal-footer">
//                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
//                        Close
//                    </button>
//                </div>
//              </div>
//            </div>

//            </div>

//            </td>
//            </tr>`;
//            $(`.click${key + 1}`).click(function () {
//                let isDelete = confirm(`Delete ${val.nik}`);
//                if (isDelete) {
//                    var el = document.getElementById(`result${key + 1}`);
//                    el.remove();
//                }
//            });


//        });


//        $('#exampleModal').html(text);

//    }).fail((result) => {
//        console.log(result);
//    });


//});

//const Getregister = (nik) => {
//    $.ajax({
//        url: "https://localhost:44396/API/Persons/GetRegisterVM/{NIK}"
//    }).done((res) => {
//        console.log(res);

//        let dataRegister = `
//                         <ul>
//                        <li><b>Full Name   : </b>${val.namaLengkap}</li>
//                        <li><b>NIK         :</b> ${val.nik}</li>
//                        <li><b>Email       : </b>${val.email}</li>
//                        <li><b>GPA       : </b>${val.gpa}</li>
//                        <li><b>Phone Number: </b>${val.phoneNumber}</li>                                        
//                        <li><b>Salary      : </b>${val.salary}</li>
//                        <li><b>Degree      : </b>${val.degree}</li>
//                    </ul>`
//        $(`#exampleModal,modal-body`).html(Getregister);
//        $(`h5.modal-title`).html(`${res.result.namaLengkap}`.toUpperCase());

//    })
//} 

//function detail(url) {
//    $.ajax({
//        url: url
//    }).done((result) => {
//        console.log(result);
//        var text = "";
//        var img = "";
//        var type = "";
//        var ability = "";
//        console.log(result.sprites.other.dream_world.front_default);
//        title = `<h1>${result.forms[0].name}</h1>`;
//        img = `<img src="${result.sprites.other.dream_world.front_default}" class="rounded mx-auto d-block">`;

//        for (let i = 0; i < result.types.length; i++) {
//            if (result.types[i].type.name == 'grass') {
//                type += `
//                    <span class="badge badge-success">Grass</span>;`

//            } if (result.types[i].type.name == 'poison') {
//                type += `
//                    <span class="badge badge-dark">Poison</span>`;
//            } if (result.types[i].type.name == 'fire') {
//                type += `
//                    <span class="badge badge-danger">Fire</span>`;
//            } if (result.types[i].type.name == 'flying') {
//                type += `
//                    <span class="badge badge-warning">Flying</span>`;
//            } if (result.types[i].type.name == 'water') {
//                type += `
//                    <span class="badge badge-primary">Water</span>`;
//            } if (result.types[i].type.name == 'bug') {
//                type += `
//                    <span class="badge badge-secondary">Bug</span>`;
//            } if (result.types[i].type.name == 'normal') {
//                type += `
//                    <span class="badge badge-light">Normal</span>`;
//            }
//        }

//        text = `
      
//               <ul>
//                <li>ID      : ${result.id}</li>
//                <li>Name    : ${result.forms[0].name}</li>
//                <li>Weight  : ${result.weight}</li>
//                <li>EXP     : ${result.base_experience}</li>
//                `;

//        for (let j = 0; j < result.abilities.length; j++) {
//            if (j == 0) {
//                ability += `<li>Ability : 
//               <ol>
//                <li>${result.abilities[0].ability.name}</li>`;
//            } else if (j == result.abilities.length - 1) {
//                ability += `
//                <li>${result.abilities[j].ability.name}</li>
//                </ol>
//               </ul>`;
//            } else {
//                ability += `<li>${result.abilities[j].ability.name}</li>`
//            }
//        }

//        $("#StarWars").modal('show');


//        $(".modal-body").html(title + img + type + text + ability + status);

//    }).fail((result) => {
//        console.log(result);
//    });
//}


//<div class="modal-body">
//    <div class="col-4">
