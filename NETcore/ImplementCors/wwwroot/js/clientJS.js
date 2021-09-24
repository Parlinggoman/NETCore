/*/*const { Button } = require("bootstrap");*/


 
   var table= $('#datatable').DataTable({
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
            "url": "/Person/GetAlldata",
            "datatype": "json",
            "dataSrc": ""
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
                "render": function (data, type, row) {
                        if (data === 0) { return data = "Male"; }
                    else {
                        return data = "Female";
                    }
                }
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
                    let obj = new Object();

                    obj.NIK = $('#NIK').val();
                    obj.phoneNumber = $('#phone').val();
                    obj.FirstName = $('#firstName').val();
                    obj.LastName = $('#lastName').val();
                    obj.BirthDate = $('#birthDate').val();
                    obj.Gender = parseInt($('#gender').val());
                    obj.Salary = parseInt($('#salary').val());
                    obj.Email = $('#email').val();
                    obj.Password = $('#password').val();
                    obj.Degree = $('#degree').val();
                    obj.GPA = $('#gpa').val();
                    obj.RoleId = parseInt($('#role').val());
                    obj.UniversityId = parseInt($('#univ').val());

                    //var obj = {


                    //    "NIK": $('#NIK').val(),
                    //    "FirstName": $('#firstName').val(),
                    //    "LastName": $('#lastName').val(),
                    //    "phoneNumber": $('#phone').val(),
                    //    "BirthDate": $('#birthDate').val(),
                    //    "Salary": parseInt($('#salary').val()),
                    //    "Email": $('#email').val(),
                    //    "Gender": parseInt($('#gender').val()),
                    //    "Password": $('#password').val(),
                    //    "Degree": $('#degree').val(),
                    //    "GPA": $('#gpa').val(),
                    //    "UniversityId": parseInt($('#univ').val()),
                    //    "RoleId": parseInt($('#role').val()),

                    //};

                    console.log(JSON.stringify(obj));
                
                    // post data to database
                    /* var data = JSON.stringify(obj);*/
                    insert(obj)
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
        url: "/Person/GetBynik/" + nik
    }).done((result) => {
        console.log(result)
        console.log(nik);
        //menampil kan data
        var text = "";

        text = `<ul>
                      <li><b>Full Name   : </b>${result.namaLengkap}</li>
                        <li><b>NIK         :</b> ${result.nik}</li>
                        <li><b>Email       : </b>${result.email}</li>
                        <li><b>University  : </b>${result.universityId}</li>

                        <li><b>GPA       : </b>${result.gpa}</li>
                        <li><b>Phone Number: </b>${result.phoneNumber}</li>
                        <li><b>Salary      : </b>${result.salary}</li>
                        <li><b>Gender      : </b>${result.gender}</li>
                        <li><b>Degree      : </b>${result.degree}</li>
                      
                </ul>`
       
           /* < li > <b>RoleId      : </b>${ result.roleId }</li >*/
 
        title = `<h5>Detail of ${result.namaLengkap}</h5>`;
        $("#exampleModalLabel").html(title);
        
        //$("#dataModal").modal('show');
        $("#data").html(text);
    })
    //}).fail((result) => {
    //    console.log(result);
    //});
   
};



//function insert(data) {
//    console.log(data);
//    $.ajax({

//        url: "/Person/PostReg/",
//        method: 'POST',
//        dataType: 'json',
//        contentType: 'application/json',
//        data: JSON.stringify(data),
//        success: function (data) {
//            console.log("Success")
//        },
//        error: console.log("Error")
//    });
//    //}).done((result) => {
//    //    //buat alert pemberitahuan jika 
//    //    alert('SUCCESS')
//    //}).fail((error) => {
//    //    //alert pemberitahuan jika gagal
//    //    alert('ERROR')

//    //});
//}

function insert(obj) {

    console.log(obj);
    $.ajax({

        url: "/Person/PostReg/",
        method: 'POST',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=utf-8',
        data: obj
    }).done((result) => {
        //buat alert pemberitahuan jika 
        /*alert('SUCCESS')*/
        Swal.fire(
            'Registration Success!',
            'You clicked the button!',
            'success'
        )

        //idmodal di hide
        $('#Register').modal('hide');

        //reload only datatable
        setInterval(function () {
            table.ajax.reload(null, false); // user paging is not reset on reload
        }, 0);
    }).fail((error) => {
        //alert pemberitahuan jika gagal
        /* alert('ERROR')*/
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
        })

    });
}

//$.ajax({
//    url: 'https://localhost:44350/accounts/registerdata/',
//    type: 'post',
//    dataType: 'json',
//    //contentType: 'application/json; charset=utf-8',
//    contentType: 'application/x-www-form-urlencoded; charset=utf-8',
//    data: data,
//    success: function (data) {
//        //$('#registerModal').modal('hide')
//        //form.reset();
//        //form.classList.add('needs-validation');
//        //swal({
//        //    title: "Success Insert Data",
//        //    icon: "success",
//        //}).then(res => dataTable.ajax.reload())
//        console.log(data)
//    },
//    error: console.log("GAGAL")
//});
//        method: 'POST',
//        dataType: 'json',
//        contentType: 'application/x-www-form-urlencoded',
//        data: JSON.stringify(obj),
//        success: function (data) {
//            console.log("Success")
//        },
//        error: console.log("Error")
//    });
//}

//    }).done((result) => {
//        //buat alert pemberitahuan jika 
//        /*alert('SUCCESS')*/
//        Swal.fire(
//            'Registration Success!',
//            'You clicked the button!',
//            'success'
//        )

//        //idmodal di hide
//     /*   $('#Register').modal('hide');*/

//        //reload only datatable
//        setInterval(function () {
//            table.ajax.reload(null, false); // user paging is not reset on reload
//        }, 0);
//    }).fail((error) => {
//        //alert pemberitahuan jika gagal
//        /* alert('ERROR')*/
//        Swal.fire({
//            icon: 'error',
//            title: 'Oops...',
//            text: 'Something went wrong!',
//        })

//    });

//}



/* url: "https://localhost:44396/API/Persons/Register/",*/
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
                setInterval(function () {
                    table.ajax.reload(null, false); // user paging is not reset on reload
                }, 0);
            }).fail((result) => {
                console.log("gagal");
            });
        }
    })



}


/*=========charts=========*/
$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44396/API/Persons/GetRegisterVM",
        type: "GET"
    }).done((result) => {
        console.log(result);
        var female = result.filter(data => data.gender === "Female").length;
        var male = result.filter(data => data.gender === "Male").length;
        console.log(female);
        var options = {
            series: [female, male],
            colors: ['#ff9999', '#00bfff'],
            chart: {
                type: 'donut',
            },
            labels: ['Female', 'Male'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#chartgender"), options);
        chart.render();
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Deleted',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
});


$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44396/API/Persons/GetRegisterVM',
        type: "GET"
    }).done((result) => {
        console.log(result);
        var ITPLN = result.filter(data => data.universityId === 1).length;
        var telkom = result.filter(data => data.universityId === 2).length;
        var USU = result.filter(data => data.universityId === 3).length;
        console.log(ITPLN);

        /*ini untuk university*/

        var universities = {
            series: [{
                data: [ITPLN, telkom, USU]
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
                categories: ["ITPLN", "TELKOM", "USU"],
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
        var chartuniv = new ApexCharts(document.querySelector("#chartuniv"), universities);
        chartuniv.render();
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Deleted',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    })

});

/*ini untuk char role*/
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44396/API/Persons/GetRegisterVM',
        type: "GET"
    }).done((result) => {
        console.log(result);
        var Manager = result.filter(data => data.roleId === 1).length;
        var HR = result.filter(data => data.roleId === 2).length;
        var User = result.filter(data => data.roleId === 3).length;
        console.log(User);

        /*ini untuk university*/

        var roles = {
            series: [Manager, HR, User],
            chart: {
                height: 390,
                type: 'radialBar',
            },
            plotOptions: {
                radialBar: {
                    offsetY: 0,
                    startAngle: 0,
                    endAngle: 270,
                    hollow: {
                        margin: 5,
                        size: '30%',
                        background: 'transparent',
                        image: undefined,
                    },
                    dataLabels: {
                        name: {
                            show: false,
                        },
                        value: {
                            show: false,
                        }
                    }
                }
            },
            colors: ['#1ab7ea', '#0084ff', '#39539E'],
            labels: ['Manager', 'HR', 'User'],
            legend: {
                show: true,
                floating: true,
                fontSize: '16px',
                position: 'left',
                offsetX: 160,
                offsetY: 15,
                labels: {
                    useSeriesColors: true,
                },
                markers: {
                    size: 0
                },
                formatter: function (seriesName, opts) {
                    return seriesName + ":  " + opts.w.globals.series[opts.seriesIndex]
                },
                itemMargin: {
                    vertical: 3
                }
            },
            responsive: [{
                breakpoint: 480,
                options: {
                    legend: {
                        show: false
                    }
                }
            }]
        };

      
        var chartrole = new ApexCharts(document.querySelector("#chartrole"),roles);
        chartrole.render();
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Deleted',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    })

});

       