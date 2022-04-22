var listObj = [];

var IndexRender = {
    render_Question: function (lstObj) {
        var html = ``;
        /*console.log(JSON.stringify(lstObj));*/
        for (var i = 0; i < lstObj.length; i++) {
            if (lstObj[i].type == 1) {
                html += `<div class="card accordion-item active">
                                    <h2 class="accordion-header" id="heading${i + 1}">
                                        <button type="button" class="accordion-button" data-bs-toggle="collapse" data-bs-target="#accordion${i + 1}" aria-expanded="true" aria-controls="accordion${i + 1}">
                                            ${i + 1}. ${lstObj[i].nameLarge}
                                        </button>
                                    </h2>
                                    <div id="accordion${i + 1}" class="accordion-collapse collapse" data-bs-parent="#accordionExample" style="">
                                        <div class="accordion-body" id="question-answer${i + 1}>
                                        <div class="col form-select-many">
                                        <textarea
                                          id="txtAnswer"
                                          class="form-control"
                                          placeholder="Please enter the answer"
                                          aria-label="Please enter the answer"
                                          aria-describedby="basic-icon-default-message2"
                                        ></textarea>
                                        </div>
                                        <div class="row mt-5 mb-2 ml-3">
                                            <div class="col">
                                                <button hidden disable data-current-index="${i}" type="button" class="btn btn-outline-primary btn-add-answer" id="${i + 1}">
                                                    <span class="tf-icons bx bx-plus"></span>&nbsp; Thêm trả lời
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-secondary btn-edit-question">
                                                    <span class="tf-icons bx bx-edit"></span>&nbsp; Sửa
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-danger btn-delete-question">
                                                    <span class="tf-icons bx bx-trash"></span>&nbsp; Xóa
                                                </button>
                                            </div>
                                        </div>
                                    </div>

                                </div>`
            } else if (lstObj[i].type == 2) {
                var lstAnswer = ``;
                if (lstObj[i].answers !== undefined || lstObj[i].answers != 0) {
                    for (var j = 0; j < lstObj[i].answers.length; j++) {
                        lstAnswer += IndexRender.render_Question_Answer(lstObj[i].type, lstObj[i].answers[j]);
                    }
                }
                if (lstAnswer === "") {
                    html += `<div class="card accordion-item">
                                    <h2 class="accordion-header" id="heading${i + 1}">
                                        <button type="button" class="accordion-button" data-bs-toggle="collapse" data-bs-target="#accordion${i + 1}" aria-expanded="true" aria-controls="accordion${i + 1}">
                                            ${i + 1}. ${lstObj[i].nameLarge}
                                        </button>
                                    </h2>
                                    <div id="accordion${i + 1}" class="accordion-collapse collapse" aria-labelledby="heading${i + 1}" data-bs-parent="#accordionExample" style="">
                                        <div class="accordion-body" id="question-answer${i + 1}></div>
                                        <div class="row mt-5 mb-2 ml-3">
                                            <div class="col">
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-primary btn-add-answer" id="${i + 1}">
                                                    <span class="tf-icons bx bx-plus"></span>&nbsp; Thêm trả lời
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-secondary btn-edit-question">
                                                    <span class="tf-icons bx bx-edit"></span>&nbsp; Sửa
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-danger btn-delete-question">
                                                    <span class="tf-icons bx bx-trash"></span>&nbsp; Xóa
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>`
                } else {
                    html += `<div class="card accordion-item">
                                    <h2 class="accordion-header" id="heading${i + 1}">
                                        <button type="button" class="accordion-button" data-bs-toggle="collapse" data-bs-target="#accordion${i + 1}" aria-expanded="true" aria-controls="accordion${i + 1}">
                                            ${i + 1}. ${lstObj[i].nameLarge}
                                        </button>
                                    </h2>
                                    <div id="accordion${i + 1}" class="accordion-collapse collapse" aria-labelledby="heading${i + 1}" data-bs-parent="#accordionExample" style="">
                                        <div class="accordion-body" id="question-answer${i + 1}>` + lstAnswer + `</div>
                                        <div class="row mt-5 mb-2 ml-3">
                                            <div class="col">
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-primary btn-add-answer" id="${i + 1}">
                                                    <span class="tf-icons bx bx-plus"></span>&nbsp; Thêm trả lời
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-secondary btn-edit-question">
                                                    <span class="tf-icons bx bx-edit"></span>&nbsp; Sửa
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-danger btn-delete-question">
                                                    <span class="tf-icons bx bx-trash"></span>&nbsp; Xóa
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>`
                }
            } else {
                var lstAnswer = ``;
                if (lstObj[i].answers !== undefined || lstObj[i].answers.length != 0) {
                    for (var j = 0; j < lstObj[i].answers.length; j++) {
                        lstAnswer += IndexRender.render_Question_Answer(lstObj[i].type, lstObj[i].answers[j], j);
                    }
                }
                if (lstAnswer === "") {
                    html += `<div class="card accordion-item">
                                    <h2 class="accordion-header" id="heading${i + 1}">
                                        <button type="button" class="accordion-button" data-bs-toggle="collapse" data-bs-target="#accordion${i + 1}" aria-expanded="true" aria-controls="accordion${i + 1}">
                                            ${i + 1}. ${lstObj[i].nameLarge}
                                        </button>
                                    </h2>
                                    <div id="accordion${i + 1}" class="accordion-collapse collapse" aria-labelledby="heading${i + 1}" data-bs-parent="#accordionExample" style="">
                                        <div class="accordion-body" id="question-answer${i + 1}"></div>
                                        <div class="row mt-5 mb-2 ml-3">
                                            <div class="col">
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-primary btn-add-answer" id="${i + 1}">
                                                    <span class="tf-icons bx bx-plus"></span>&nbsp; Thêm trả lời
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-secondary btn-edit-question">
                                                    <span class="tf-icons bx bx-edit"></span>&nbsp; Sửa
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-danger btn-delete-question">
                                                    <span class="tf-icons bx bx-trash"></span>&nbsp; Xóa
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>`
                } else {
                    html += `<div class="card accordion-item">
                                    <h2 class="accordion-header" id="heading${i + 1}">
                                        <button type="button" class="accordion-button" data-bs-toggle="collapse" data-bs-target="#accordion${i + 1}" aria-expanded="true" aria-controls="accordion${i + 1}">
                                            ${i + 1}. ${lstObj[i].nameLarge}
                                        </button>
                                    </h2>
                                    <div id="accordion${i + 1}" class="accordion-collapse collapse" aria-labelledby="heading${i + 1}" data-bs-parent="#accordionExample" style="">
                                        <div class="accordion-body" id="question-answer${i + 1}">` + lstAnswer + `</div>
                                        <div class="row mt-5 mb-2 ml-3">
                                            <div class="col">
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-primary btn-add-answer" id="${i + 1}">
                                                    <span class="tf-icons bx bx-plus"></span>&nbsp; Thêm trả lời
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-secondary btn-edit-question">
                                                    <span class="tf-icons bx bx-edit"></span>&nbsp; Sửa
                                                </button>&nbsp;
                                                <button data-current-index="${i}" type="button" class="btn btn-outline-danger btn-delete-question">
                                                    <span class="tf-icons bx bx-trash"></span>&nbsp; Xóa
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>`
                }

            }
        }
        return html;
    },
    render_Question_Answer: function (questionType, answer, index) {
        var html = ``;
        if (questionType == 2) {
            html += `<div class="form-check">
                <input name="default-radio-${index}" class="form-check-input" type="radio" value="" id="defaultRadio${index}" checked="">
                <label class="form-check-label" for="defaultRadio${index}"> ${answer} </label>
                </div>`
        } else {
            html += `<div class="form-check">
                         <input class="form-check-input" type="checkbox" value="" id="defaultCheck${index}">
                         <label class="form-check-label" for="defaultCheck${index}"> ${answer} </label>
                         </div>`
        }
        return html;
    }
}

var Index = function () {
    /* ------ Methods ------ */
    var addNewQuestion = function () {
        var formAction = $('#question-modal-action').val(); // check kiểu thao tác, thêm mới hay sửa.
        var obj = new Object();
        obj.nameLarge = document.getElementById('nameLarge').value;
        obj.type = document.getElementById("defaultSelect").value;
        obj.answers = [];
        if (parseInt(formAction) == 1) {
            // thêm mới.           
            listObj.push(obj);

        } else if (parseInt(formAction) == 2) {
            var currentIndex = parseInt($('#current-object-index').val());
            listObj[currentIndex] = obj;
        }
        $("#accordionExample").html(IndexRender.render_Question(listObj));
        resetModal();
    }

    var resetModal = function () {
        $('#nameLarge').val('');
        $('#defaultSelect').val(0);
        $('#question-modal').modal('hide');
        $('#question-modal-action').val(1);
    }

    var showCreateModal = function () {
        resetModal();
        $('#question-modal').modal('show');
    }

    var showEditModal = function (obj) {
        $('#nameLarge').val(obj.nameLarge);
        $('#defaultSelect').val(obj.type);
        $('#question-modal-action').val(2);
        $('#question-modal').modal('show');
    }

    var showAddAnswerModal = function () {
        $('#add-answer-modal').modal('show');
    }

    var addNewAnswer = function (currentIndex) {
        var currentObject = listObj[parseInt(currentIndex)];
        var newAnswer = document.getElementById('txt-answer').value;
        var answers = [];
        if (currentObject.answers !== undefined) {
            answers.push(...currentObject.answers)
        }
        answers.push(newAnswer)
        currentObject.answers = answers;
        listObj[currentIndex] = currentObject;
        console.log(JSON.stringify(answers));
        $("#accordionExample").html(IndexRender.render_Question(listObj));
        $('#txt-answer').val('');
        $('#add-answer-modal').modal('hide');
    }

    /* ------ Handles ------ */
    var handleBox = function () {
        $("#btnSubmitQuestion").click(function () {
            addNewQuestion();
        })

        $(document).on('click', '.btn-add-answer', function () {
            var currentIndex = $(this).attr('data-current-index');
            var currentObject = listObj[parseInt(currentIndex)];
            $('#current-question-index').val(currentIndex);
            showAddAnswerModal();
        });

        // add event vào các phần tử sinh ra bằng js
        $(document).on('click', '.btn-edit-question', function () {
            var currentIndex = $(this).attr('data-current-index');
            var currentObject = listObj[parseInt(currentIndex)];
            $('#current-object-index').val(currentIndex);
            showEditModal(currentObject);
        });


        // add event vào các phần tử sinh ra bằng js
        $(document).on('click', '.btn-delete-question', function () {
            var currentIndex = $(this).attr('data-current-index');
            var currentObject = listObj[parseInt(currentIndex)];
            $('#current-object-index').val(currentIndex);
            listObj.splice(currentIndex, 1);
            $("#accordionExample").html(IndexRender.render_Question(listObj));
        });

        $('#btn-add-question').click(function () {
            showCreateModal();
        })

        $(document).on('click', '.add-answer', function () {
            let currentIndex = document.getElementById('current-question-index').value;
            addNewAnswer(currentIndex,)
        });
    }
    return {
        initialize: function () {
            handleBox();
        }
    }
}();

jQuery(document).ready(function () {
    Index.initialize();
});