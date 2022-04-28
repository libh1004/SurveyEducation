var IndexRender = {
    render_Question: function (lstObj) {
        var html = ``;
        return html;
    },
    render_Question_Answer: function (questionType, answers, questionId) {
        var html = ``;
        return html;
    }
}


var Index = function () {
    /* ------ Methods ------ */
    var getStatistic = async function (obj) {
        
    }

    /* ------ Handles ------ */
    var handleBox = async function () {
        $('[data-box="statistic-box"]').map(async function (item) {
            getStatistic($(item));
        });
    }

    return {
        initialize: async function () {
            await handleBox();
        }
    }
}();

jQuery(document).ready(function () {
    Index.initialize();
});