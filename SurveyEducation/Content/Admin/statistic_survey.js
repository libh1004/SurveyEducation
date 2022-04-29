var StatisticRender = {
    render_Table_Statistic: function (obj) {
        var html = ``;
        for (var i = 0; i < obj.length; i++) {
            var statusHtml = StatisticRender.render_Status(obj[i].Survey.Status);
            html += `<tr>
                    <td>#${obj[i].Survey.Id}</td>
                    <td>${obj[i].Survey.Name}</td>
                    <td>${obj[i].SurveyHistories.length}</td>
                    <td>${statusHtml}</td>
                    <td>
                    <div class="dropdown">
                    <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                    <i class="bx bx-dots-vertical-rounded"></i>
                    </button>
                    <div class="dropdown-menu">
                    <a class="dropdown-item btnShowDetail" id="${obj[i].Survey.Id}"><i class="fa-solid fa-eye"></i>&nbsp;Detail</a>
                    </div>
                    </div>
                    </td>
                    </tr>`
        }
        return html;
    },

    render_Status: function (status) {
        html = ``;
        if (status == 1) {
            html = `<span class="badge bg-label-primary me-1">Active</span>`
        } else if (status == 0) {
            html = `<span class="badge bg-label-warning me-1">Pending</span>`
        } else if (status == 2) {
            html = `<span class="badge bg-label-success me-1">Completed</span>`
        }
        return html;
    }
}

var Statistic = function () {
    /* ------ Methods ------ */
    var getStatistic = async function () {
        $.ajax({
            type: "GET",
            url: "/Admin/Survey/StatisticSurveyApi",
            contentType: "application/json charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                console.log(textStatus + ": " + jqXHR.status);
                if (textStatus === "success" || jqXHR.status == 200) {
                    $('#tb-statistic').html(StatisticRender.render_Table_Statistic(data))
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus + ": " + jqXHR.status + " " + errorThrown);
            }
        });
    }

    var showDetail = async function (id) {
        window.location.href = '/Admin/Survey/DetailStatisticSurvey/' + id
    }

    /* ------ Handles ------ */
    var handleBox = async function () {
        $('#tb-statistic').map(async function () {
            await getStatistic();
        });

        $(document).on('click', '.btnShowDetail', async function () {
            await showDetail(this.id);
        });
    }

    return {
        initialize: async function () {
            await handleBox();
        }
    }
}();

jQuery(document).ready(function () {
    Statistic.initialize();
});