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

let tools_flag = true, filter = true, date_flight, type_flight = true, filter_location = true;

function changeVisibility(elem, num) {
    let el = $(elem);
    //console.log("show func");
    let show = "show";
    let temp = false;
    //console.log(el.hasClass(show));

    switch (num) {
        case 1:
            temp = tools_flag;
            tools_flag = !tools_flag;
            break;
        case 2:
            temp = filter;
            filter = !filter;
            break;
        case 3:
            temp = date_flight;
            date_flight = !date_flight;
            break;
        case 4:
            temp = type_flight;
            type_flight = !type_flight;
            break;
        case 5:
            temp = filter_location;
            filter_location = !filter_location;
            break;
        default:

            break;
    }

    //if (el.hasClass(show)) {
    if (temp) {
        el.removeClass(show);
        console.log("i remove");
    }
    else {
        el.addClass(show);
    }
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



var slideIndex = 1;

//showSlides(slideIndex, name_container);

function plusSlides(n, name_container) {
    showSlides(slideIndex += n, name_container);
}

function currentSlide(n, name_container) {
    showSlides(slideIndex = n, name_container);
}

function showSlides(n, name_container) {
    var i; //mySlides
    var name = "count-of-images" + name_container;
    var slides = document.getElementsByClassName(name);
    //alert(slides.length);
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    slides[slideIndex - 1].style.opacity = 1;
    dots[slideIndex - 1].className += " active";
}