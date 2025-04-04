﻿(function () {
    ClassicEditor
        .create(document.querySelector('.editor'), {
            toolbar: ['heading', '|',
                'bold', 'italic', 'underline', 'bulletedList', 'numberedList', '|',
                'alignment', 'blockQuote', '|',
                'fontSize', 'fontBackgroundColor', 'fontColor', '|',
                'link', 'insertImage', 'insertTable', 'codeBlock'],
            ckfinder: {
                uploadUrl: '/ckfinder/connector?command=QuickUpload&type=Files&responseType=json'
            },
            image: {
                toolbar: ['toggleImageCaption', 'imageTextAlternative']
            },
            codeBlock: {
                languages: [
                    { language: 'css', label: 'CSS' },
                    { language: 'html', label: 'HTML' }
                ]
            },
            alignment: {
                options: ['left', 'right', 'center', 'justify']
            },
            fontSize: {
                options: [
                    'tiny',
                    'small',
                    'default',
                    'big',
                    'huge'
                ]
            },
            heading: {
                options: [
                    { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                    { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                    { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                    { model: 'heading3', view: 'h2', title: 'Heading 3', class: 'ck-heading_heading3' },
                    { model: 'heading4', view: 'h2', title: 'Heading 4', class: 'ck-heading_heading4' },
                    { model: 'heading5', view: 'h2', title: 'Heading 5', class: 'ck-heading_heading5' },
                    { model: 'heading6', view: 'h2', title: 'Heading 6', class: 'ck-heading_heading6' },
                ]
            }
        })
        .catch(error => {
            console.log(error);
        });
})()