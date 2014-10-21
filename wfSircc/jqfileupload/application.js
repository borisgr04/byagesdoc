/*
 * jQuery File Upload Plugin JS Example 5.0.2
 * https://github.com/blueimp/jQuery-File-Upload
 *
 * Copyright 2010, Sebastian Tschan
 * https://blueimp.net
 *
 * Licensed under the MIT license:
 * http://creativecommons.org/licenses/MIT/
 */

/*jslint nomen: true */
/*global $ */

$(function () {
    'use strict';

   
    // Initialize the jQuery File Upload widget:
    $('#fileupload').fileupload({
        progress: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            data.context.find('.progress-bar-success').css(
            'width',
            progress + '%'
            );

         
            i = i + 1;
        },
        progressall: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('.totalprogress').css(
               'width',
               progress + '%'
           );
        }
    });



     //Load existing files:
        //$.getJSON($('#fileupload form').prop('action'), function (files) {
        //    var fu = $('#fileupload').data('fileupload');
        //    fu._adjustMaxNumberOfFiles(-files.length);
        //    fu._renderDownload(files)
        //        .appendTo($('#fileupload .files'))
        //        .fadeIn(function () {
        //            // Fix for IE7 and lower:
        //            $(this).show();
        //        });
    //});
    var i = 1;
    $('#fileupload')
    .bind('fileuploadstop', function (e, data) {
       // i = i + 1;
       
        console.log("subio todo..");
        //window.opener.location.reload();
    });

    $('#fileupload').bind('fileuploaddone', function (e, data) {
        
        if (data.jqXHR.responseText || data.result) {
            var fu = $('#fileupload').data('fileupload');
            var JSONjQueryObject = (data.jqXHR.responseText) ? jQuery.parseJSON(data.jqXHR.responseText) : data.result;
            fu._adjustMaxNumberOfFiles(JSONjQueryObject.files.length);
            //                debugger;
            fu._renderDownload(JSONjQueryObject.files)
                .appendTo($('#fileupload .files'))
                .fadeIn(function () {
                    // Fix for IE7 and lower:
                    $(this).show();
                });
        }
    });

    // Open download dialogs via iframes,
    // to prevent aborting current uploads:
    $('#fileupload .files a:not([target^=_blank])').live('click', function (e) {
        e.preventDefault();
        $('<iframe style="display:none;"></iframe>')
            .prop('src', this.href)
            .appendTo('body');
    });

});