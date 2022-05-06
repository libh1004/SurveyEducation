var IndexRender = {
    render_Question: function (lstObj) {
        var html = ``;
        lstObj.forEach(function (item, index) {
            if (item.QuestionType == 1) {
                html += `<div id="id_22" data-type="control_radio" data-qid="22" data-order="5" data-selectioncount="0" class="form-line clearfix isNotSelected lineAlignment-Top mt-5" style="z-index: 1;">
                            <div class="question-wrapper questionWrapper  false">
                                <label id="label_22" class="form-label form-label-top" for="none" style="width: 100%;">
                                    <div class="editor-container editorHasText" style="display: inline; width: 100%;">
                                        <div class="inlineEditor" placeholder="Type a question" data-gramm="false" style="width: 100%;">
                                            <p data-current-index="${item.Id}" >Câu hỏi ${index + 1}: ${item.Content}</p>
                                        </div>
                                    </div>
                                </label>
                                <div class="form-input-wide" data-layout="full" style="position: relative;">
                                    <div class="form-single-column" role="group" aria-labelledby="label_22">
                                        <p>Câu trả lời:</p>
                                       
                                        <input class="form-control" type="text" placeholder="Điền câu trả lời" id="input-text-${item.Id}"/>
                                    </div>
                                </div>
                            </div>
                        </div>`;
            } else if (item.QuestionType == 2) {
                if (item.Answers != null) {
                    var lstAnswer = IndexRender.render_Question_Answer(item.QuestionType, item.Answers.split('|'), item.Id);
                }
                html += `<div id="id_22" data-type="control_radio" data-qid="22" data-order="5" data-selectioncount="0" class="form-line clearfix isNotSelected lineAlignment-Top mt-5" style="z-index: 1;">
                            <div class="question-wrapper questionWrapper  false">
                                <label id="label_22" class="form-label form-label-top" for="none" style="width: 100%;">
                                    <div class="editor-container editorHasText" style="display: inline; width: 100%;">
                                        <div class="inlineEditor" placeholder="Type a question" data-gramm="false" style="width: 100%;">
                                            <p data-current-index="${item.Id}">Câu hỏi ${index + 1}: ${item.Content}</p>
                                        </div>
                                    </div>
                                </label>
                                <div class="form-input-wide" data-layout="full" style="position: relative;">
                                    <div class="form-single-column" role="group" aria-labelledby="label_22" data-component="radio">
                                        <p>Câu trả lời:</p>
                                        ${lstAnswer}
                                    </div>
                                </div>
                            </div>
                        </div>`;
            } else {
                if (item.Answers != null) {
                    var lstAnswer = IndexRender.render_Question_Answer(item.QuestionType, item.Answers.split('|'), item.Id);
                }
                html += `<div id="id_22" data-type="control_radio" data-qid="22" data-order="5" data-selectioncount="0" class="form-line clearfix isNotSelected lineAlignment-Top mt-5" style="z-index: 1;">
                            <div class="question-wrapper questionWrapper  false">
                                <label id="label_22" class="form-label form-label-top" for="none" style="width: 100%;">
                                    <div class="editor-container editorHasText" style="display: inline; width: 100%;">
                                        <div class="inlineEditor" placeholder="Type a question" data-gramm="false" style="width: 100%;">
                                            <p data-current-index="${item.Id}">Câu hỏi ${index + 1}: ${item.Content}</p>
                                        </div>
                                    </div>
                                </label>
                                <div class="form-input-wide" data-layout="full" style="position: relative;">
                                    <div class="form-single-column" role="group" aria-labelledby="label_22" data-component="checkbox">
                                        <p>Câu trả lời:</p>
                                        ${lstAnswer}
                                    </div>
                                </div>
                            </div>
                        </div>`;
            }
        });
        return html;
    },
    render_Question_Answer: function (questionType, answers, questionId) {
        var html = ``;
        if (questionType == 2) {
            answers.forEach(function (item, index) {
                if (index == 0) {
                    html = `<div class="form-check">
                    <span class="form-radio-item mt-4" style="clear: left;">
                    <span class="dragger-item"></span>
                    <input aria-describedby="label_22" name="radio" type="radio" tabindex="-1" class="form-radio" id="input-radio-${questionId}" value="${item}" checked>
                    <span>
                    <div class="editor-container editorHasText" style="display: inline-block;">
                    <label class="inlineEditor" data-gramm="false" id="label-input-${questionId}" style="display: inline-block;">
                    ${item}
                    </label>
                    </div>
                    </span>
                    </span>
                    </div>`
                } else {
                    html += `<div class="form-check">
                    <span class="form-radio-item mt-4" style="clear: left;">
                    <span class="dragger-item"></span>
                    <input aria-describedby="label_22" name="radio" type="radio" tabindex="-1" class="form-radio" id="input-radio-${questionId}" value="${item}">
                    <span>
                    <div class="editor-container editorHasText" style="display: inline-block;">
                    <label class="inlineEditor" data-gramm="false" id="label-input-${questionId}" style="display: inline-block;">
                    ${item}
                    </label>
                    </div>
                    </span>
                    </span>
                    </div>`
                }
            })
        } else {
            answers.forEach(function (item, index) {
                html += `<div class="form-check mt-3">
                <span class="form-radio-item mt-4" style="clear: left;">
                    <span class="dragger-item"></span>
                    <input aria-describedby="label_22" type="checkbox" name="chk[]" tabindex="-1" class="form-radio" id="input-checkbox-${questionId}" value="${item}">
                    <span>
                    <div class="editor-container editorHasText" style="display: inline-block;">
                    <label class="inlineEditor" data-gramm="false" id="label-input-${questionId}" style="display: inline-block;">
                    ${item}
                    </label>
                    </div>
                    </span>
                    </span>
                    </div>`
            });
        }
        return html;
    }
}

var Index = function () {
    /* ------ Methods ------ */
    var getSurvey = async function (obj, id) {
        //$.ajax({
        //    type: "GET",
        //    url: "/Answer/GetSurvey/" + id,
        //    contentType: "application/json charset=utf-8",
        //    dataType: "json",
        //    success: function (data, textStatus, jqXHR) {
        //        console.log(textStatus + ": " + jqXHR.status);
        //        if (textStatus === "success" || jqXHR.status == 200) {
        //            $(obj).html(IndexRender.render_Question(data.Questions))
        //        }
        //    },
        //    error: function (jqXHR, textStatus, errorThrown) {
        //        console.log(textStatus + ": " + jqXHR.status + " " + errorThrown);
        //    }
        //});

        fetch("/Answer/GetSurvey/" + id, {
            method: "GET"
        }).then(response => response.json()).then(json => {
            $(obj).html(IndexRender.render_Question(json.Questions))
        })
    }

    var submitSurvey = async function (obj, id) {
        var json = new Object();
        json.SurveyId = id;
        json.Answers = obj;

        var rawResponse = await fetch('/Answer/SubmitSurvey', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(json)
        })

        var content = await rawResponse.json();
        console.log(content);
    }

    /* ------ Handles ------ */
    var handleBox = async function () {
        $('[data-box="questions-box"]').map(async function (index, item) {
            var id = document.URL.split('/')[document.URL.split('/').length - 1];
            await getSurvey($(item), id);
        });

        $('#btnSubmitAnswer').click(async function () {
            //var questionValue = $('data-current-index').val();
            //alert(questionValue);
            ////alert(questionValue);
            //var answerValue = "";
            //lstObj.forEach(function (item, index) {
            //    if (item.QuestionType == 1) {
            //        answerValue = $("input[value]").val();
            //    } else if (item.QuestionType == 2) {
            //        answerValue = $("input[checked]").val();
            //    } else if (item.QuestionType == 3) {
            //        answersValue = item.Answers.split('|');
            //        alert(answersValue)

            //    }
            //});
            var results = [];
            var cbAnswers = [];
            $('input').each(async function () {
                if ($(this).attr('type') == 'text') {
                    results.push({
                        QuestionId: this.id.split('-').pop(),
                        Answer: this.value
                    })
                } else if ($(this).attr('type') == 'radio') {
                    if ($(this).is(':checked')) {
                        results.push({
                            QuestionId: this.id.split('-').pop(),
                            Answer: this.value
                        })
                    }
                }
            })
            var cbQId = null;
            var cboxes = document.getElementsByName('chk[]')
            for (var i = 0; i < cboxes.length; i++) {
                if (cboxes[i].checked) {
                    cbQId = cboxes[i].id.split('-').pop()
                    cbAnswers.push(cboxes[i].value)
                }
            }
            results.push({
                QuestionId: cbQId,
                Answer: cbAnswers.join('|')
            })
            console.log(JSON.stringify(results))
            var id = document.URL.split('/')[document.URL.split('/').length - 1];
            await submitSurvey(results, id);
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