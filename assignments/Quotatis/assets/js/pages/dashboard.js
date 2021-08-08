import $ from "jquery";
import "./../../styles/pages/dashboard.scss";

document.addEventListener("DOMContentLoaded", function () {
    $(".dashboard-api-card").each((i, card) => {
        let url = $(card).data("route");

        if (url) {
            $.ajax(url, {
                success: (data) => {
                    $(card).find(".api-title").html(data.title);
                    $(card).find(".api-value").html(data.value);
                    $(card).find(".api-value").html(data.value);
                    $(card).find(".api-difference").html(data.difference);
                    $(card).find(".api-difference-text").html(data.difference_text);
                    $(card).find(".api-icon").replaceWith(feather.icons[data.icon].toSvg());

                    if (data.trend === "up") {
                        $(card).find(".api-difference").addClass("badge-soft-success");
                    } else {
                        $(card).find(".api-difference").addClass("badge-soft-danger");
                    }

                    $(card).find(".dashboard-loader").addClass("d-none");
                    $(card).find(".card-content").removeClass("d-none");
                }
            });
        }
    })
});