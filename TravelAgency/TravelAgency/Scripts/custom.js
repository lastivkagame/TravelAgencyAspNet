function onSearch(e) {
    if (e.key === "Enter") {
        location.href = `/Tour/Index?search=${e.target.value}`;
    }
}

function onBtnSerch(e)
{
    location.href = `/Tour/Index?search=${inputsearch.value}`;
}
function ChoosenUrlImg(element) {
    var selector = $(element).data("input-to-show");
    var selector2 = $(element).data("input-to-hide");

    if ($(element).is(':checked')) {
        $(selector).hide();
        $(selector2).show();
    } else {
        $(selector).show();
        $(selector2).hide();
    }
}

function setFilter(element) {
    var type = $(element).data("type");
    var value = $(element).val();

    $("#toursContainer").load(`/Tour/Filter?type=${type}&value=${encodeURIComponent(value)}`);
}


var workModule = (function () {
    var selectors = {
        bage: "#badge"
    };



    function onGetStateClick(element) {
        var url = $(element).data("href");



        $.ajax({
            url: url,
            type: "POST",
            dataType: "json",
            success: (data) => {
                updateState(data.result);
            },
            error: (data) => {
                console.log(data.result);
            }
        });
    }



    function updateState(state) {
        $(selectors.bage).text(state);
    }



    return {
        onGetStateClick: onGetStateClick
    }
})(jQuery)

function MyDoSignOut(element) {
    var url = $(element).data("href");
    $.ajax({
        url: url,
        type: "POST",
        dataType: "*",
        success: () => {
            //$("#mylogin_signin").removeClass("d-none");
            //$("#mybtn_signout").addClass("d-none");
        },
        error: (data) => {
            console.log(data)
        }
    });


}