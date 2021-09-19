/*/*const { Button } = require("bootstrap");*/


$(document).ready(function () {
    $('#datatable').DataTable({
        "dom": 'Bfrtip',
        "buttons": [
            {
                extend: 'excelHtml5',
                exportOptions: {
                    columns: [1, 2, 4, 5,6,7]
                },
                bom: true,
                id: "expExcel"
            }
            ,
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [1, 2, 4, 5, 6, 7]
                },
                bom: true,
                id: "expPdf"
            }
        ],

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
                            onclick="detail('${row["nik"]}')">Detail</button>
                            <button type = "button" class="btn btn-danger"
                             id="btnDelete"
                             onclick = "deleted('${row["nik"]}')">Delete</button ></td>`;
                
                },
               
                 "orderable": false
            }

        ],
           });
 
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


/*===============Detail=================*/


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


/*=============Delete================*/
function deleted(nik) {
    console.log(nik)
    Swal.fire({
        title: `Are you sure to delete data nik = ${nik}?`,
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "https://localhost:44396/API/Persons/" + nik,
                type: 'DELETE'
            }).done((result) => {
                console.log("berhasil");

                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }).fail((result) => {
                console.log("gagal");
            });
        }
    })



}













////delete university
//deleteModalUniversity = (url) => {
//    $.ajax({
//        url: url,
//    }).done((result) => {
//        console.log(result.result.universityId);

//        Swal.fire({
//            title: 'Hapus Data',
//            text: `Anda akan menghapus data ${result.result.name} !`,
//            icon: 'warning',
//            showCancelButton: true,
//            confirmButtonColor: '#3085d6',
//            cancelButtonColor: '#d33',
//            confirmButtonText: 'Yes, delete!'
//        }).then((isDelete) => {
//            if (isDelete.isConfirmed) {

//                $.ajax({
//                    url: `http://localhost:5002/api/university/${result.result.universityId}`,
//                    method: 'DELETE',
//                    success: function (data) {

//                        Swal.fire(
//                            'Deleted!',
//                            'Data berhasil dihapus.',
//                            'success'
//                        )

//                        $('#myTable').DataTable().ajax.reload();
//                    },
//                })
//            }
//        })

//    }).fail((result) => {
//        console.log(result);
//    });
//}

/*=========charts=========*/
$.ajax({
    url: 'https://localhost:44396/API/Persons/GetRegisterVM',
    type: "GET"
}).done((result) => {
    console.log(result);
    var female = result.result.filter(data => data.gender === "Female").length;
    var male = result.result.filter(data => data.gender ==="Male").length;
    console.log(male);
    var options = {
        series: [{
            data: [male, female]
        }],
        chart: {
            height: 350,
            type: 'bar',
        },
        plotOptions: {
            bar: {
                borderRadius: 10,
                dataLabels: {
                    position: 'top', // top, center, bottom
                },
            }
        },
        dataLabels: {
            enabled: true,
            formatter: function (val) {
                return val;
            },
            offsetY: -20,
            style: {
                fontSize: '12px',
                colors: ["#304758"]
            }
        },
        xaxis: {
            categories: ["Male", "Female"],
            position: 'top',
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false
            },
            crosshairs: {
                fill: {
                    type: 'gradient',
                    gradient: {
                        colorFrom: '#D8E3F0',
                        colorTo: '#BED1E6',
                        stops: [0, 100],
                        opacityFrom: 0.4,
                        opacityTo: 0.5,
                    }
                }
            },
            tooltip: {
                enabled: true,
            }
        },
        yaxis: {
            axisBorder: {
                show: false
            },
            axisTicks: {
                show: false,
            },
            labels: {
                show: false,
                formatter: function (val) {
                    return val;
                }
            }
        }
    };
    var chart = new ApexCharts(document.querySelector("#chart"), options);
    chart.render();
}).fail((error) => {
    Swal.fire({
        title: 'Error!',
        text: 'Data Cannot Deleted',
        icon: 'Error',
        confirmButtonText: 'Next'
    })
})