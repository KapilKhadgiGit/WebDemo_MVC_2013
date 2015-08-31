/*
 * Bootstrap Image Gallery JS Demo 3.0.1
 * https://github.com/blueimp/Bootstrap-Image-Gallery
 *
 * Copyright 2013, Sebastian Tschan
 * https://blueimp.net
 *
 * Licensed under the MIT license:
 * http://www.opensource.org/licenses/MIT
 */

/*jslint unparam: true */
/*global blueimp, $ */

$(function () {
    'use strict';

    // Load demo images from flickr:
    $.ajax({
        url: '/api/ImageGallery',
        dataType: 'json',
    }).success(function (result) {

        var linksContainer = $('#links'),
            baseUrl;
        // Add the demo images as links with thumbnails to the page:
        $.each(result, function (index, result) {
            baseUrl = '/ImageResolver.ashx?size=s&ImageName=' + result.Name;
            var baseUrlLarge = '/ImageResolver.ashx?size=m&imagename=' + result.Name;
            // var baseUrlLarge = '/Photos/Diwali Zeon 2014/' + result.Name;
            $('<a/>')
                // .append($('<img>').prop('src', baseUrl + '_s.jpg'))
                .append($('<img>').prop('src', baseUrl))
                .prop('href', baseUrlLarge)
                .prop('title', result.Title)
                .attr('data-gallery', '')
                .appendTo(linksContainer);
        });
    }).error(function (msg) {
        var message = msg;
        alert(msg.responseText);
        //debugger;
    });;

    $('#borderless-checkbox').on('change', function () {
        var borderless = $(this).is(':checked');
        $('#blueimp-gallery').data('useBootstrapModal', !borderless);
        $('#blueimp-gallery').toggleClass('blueimp-gallery-controls', borderless);
    });

    $('#fullscreen-checkbox').on('change', function () {
        $('#blueimp-gallery').data('fullScreen', $(this).is(':checked'));
    });

    $('#image-gallery-button').on('click', function (event) {
        event.preventDefault();
        blueimp.Gallery($('#links a'), $('#blueimp-gallery').data());
    });

    $('#video-gallery-button').on('click', function (event) {
        event.preventDefault();
        blueimp.Gallery([
            {
                title: 'Sintel',
                href: 'http://media.w3.org/2010/05/sintel/trailer.mp4',
                type: 'video/mp4',
                poster: 'http://media.w3.org/2010/05/sintel/poster.png'
            }
           
        ], $('#blueimp-gallery').data());
    });

});
