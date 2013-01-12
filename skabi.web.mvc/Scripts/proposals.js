$(document).ready(function () {



    $("#proposalsMenu .menuitem").live("click", function (event) {

        //proposals.collapse([proposals.columns.carmodels]);
        var currentColumn = $(this).parents(".menuColumn");
        var nextColumn = $(this).parents("td").next().find(".menuColumn");
        var nextColumns = $(this).parents("td").nextAll().find(".menuColumn");
        var nextdiv = $(this).parents("td").next().find(".menuColumn").first();
        var nextdivs = $(this).parents("td").nextAll().find(".menuColumn");
        var id = $(this).attr("id");
        var action = $(this).parents(".menuColumn").attr("action");
        console.log(nextColumns);






        if (nextColumn.hasClass("expanded")) {
            nextColumn.removeClass("expanded");
            nextColumns.each(function (columnindex, column) {
                $(column).animate({
                    "margin-left": -$(column).width()
                }, { duration: 1000, easing: "easeOutExpo" }, function () {
                    // Animation complete.
                });
            });




        } else {

        }



        //nextColumns.promise().done(function () {

        var request = $.ajax({
            url: "/proposals/" + action,
            //type: "POST",
            dataType: 'json',
            data: { "id": id },
            success: function (items) {
                //console.log(items);


                //var width = nextdiv.width();
                //var testa = nextdiv.css("margin-left", width - nextdiv.position().left);
                //console.log(width);
                //console.log(nextdiv.css("margin-left"));




                //console.log(currentColumn.position().left);
                //console.log(currentColumn.width());
                var currentcolumnx = currentColumn.position().left + currentColumn.width();
                //console.log(currentcolumnx);
                //console.log(nextdiv.width());




                //var currentcolumnwidth = currentcolumnx.width();


                //proposals.expand(proposals.columns.carmodels);
            }
        });

        //});
        $.when(request, nextColumn, nextColumns).done(function (items, column, columns) {
            console.log("then fired");

            nextColumn.find("table").empty();
            //console.log(items[0]);
            $(items[0]).each(function (index, item) {
                var row = $("<tr/>");
                var cell = $("<td/>");
                var link = $("<div/>");
                row.append(cell);
                cell.append(link);
                link.text(item.Name);
                link.addClass("menuitem");
                link.attr("id", item.ID);


                nextColumn.find("table").append(row);
            });

            nextdiv.css("margin-left", -40 - nextdiv.width());

            nextColumn.addClass("expanded");
            nextColumn.animate({
                "margin-left": 0
            }, { duration: 1000, easing: "easeOutExpo" }, function () {
                // Animation complete.
            });
        });

    });

    /*
    $("#carbrands .carbrand").click(function () {
    proposals.collapse([proposals.columns.carmodels]);
    var id = $(this).attr("id");
    $.ajax({
    url: "/proposals/GetCarModels",
    //type: "POST",
    dataType: 'json',
    data: { "id": id },
    success: function (carmodels) {
    console.log(carmodels);

    $(carmodels).each(function (index, carmodel) {
    //console.log(carmodel);
    var cell = $("<tr/>").append($("<td/>"));
    var link = $("<div/>");
    cell.append(link);
    link.text(carmodel.Name);
    link.addClass("carmodel");
    link.attr("id", carmodel.ID);

    $("#carmodels").find("table").append(cell);
    });

    proposals.expand(proposals.columns.carmodels);
    }
    });
    });

    /*
    $("#carmodels .carmodel").live("click", function () {
    var id = $(this).attr("id");
    $.ajax({
    url: "/proposals/GetCarModelTypes",
    //type: "POST",
    dataType: 'json',
    data: { "id": id },
    success: function (carmodeltypes) {
    console.log(carmodeltypes);

    $(carmodeltypes).each(function (index, carmodeltype) {
    console.log(carmodeltype);
    var link = $("<span/>").text(carmodeltype.cu);

    $("#div_types").append(link);
    });
    }
    });
    });
    */



    $(".menuColumn").promise().done(function () {
        console.log("lala");
    });
});

var proposals = {
    columns: {
        carbrands: function () {
            return $("#carbrands");
        },
        carmodels: function () {
            return $("#carmodels");
        },
        carmodeltypes: function () {
            return $("#carmodeltypes");
        }
    },
    collapse: function (column) {
        $(columns).each(function (column, index) {

            //proposals.columns.carmodels().css("margin-left", proposals.columns.carmodels().width());
            proposals.columns.carmodels().animate({
                left: proposals.columns.carmodels().width()
              }, 5000, function() {
                // Animation complete.
              });
        });
    },
    expand: function (column) {

    }
}