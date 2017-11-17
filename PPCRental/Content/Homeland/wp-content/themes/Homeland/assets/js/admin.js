(function($) {
  "use strict";
  
  // Tabs
  $(document).ready(function(){
    $('ul.mabuc-tabs li').click(function(){
      var tab_id = $(this).attr('data-tab');

      $('ul.mabuc-tabs li').removeClass('current');
      $('.mabuc-tab-content').removeClass('current');

      $(this).addClass('current');
      $("#"+tab_id).addClass('current');
    })
  });


  // Uploads
  var formfield = '';
  var formfield_video = '';
  var formfield_audio = '';

    // Misc Images

    jQuery('#upload_image_button_homeland_custom_icon').click(function() {
      formfield_video = jQuery('#homeland_custom_icon').attr('name');
      tb_show('', 'media-upload.php?type=image&amp;width=640&amp;height=550&amp;TB_iframe=true');
      return false;           
    }); 

    jQuery('#upload_image_button_avatar').click(function() {
      formfield = jQuery('#homeland_custom_avatar').attr('name');
      tb_show('', 'media-upload.php?type=image&amp;width=640&amp;height=550&amp;TB_iframe=true');
      return false;           
    });


    // Header Images

    jQuery('#upload_image_button_homeland_hdimage').click(function() {
      formfield = jQuery('#homeland_hdimage').attr('name');
      tb_show('', 'media-upload.php?type=image&amp;width=640&amp;height=550&amp;TB_iframe=true');
      return false;           
    });


    // Background Images

    jQuery('#upload_image_button_homeland_bgimage').click(function() {
      formfield = jQuery('#homeland_bgimage').attr('name');
      tb_show('', 'media-upload.php?type=image&amp;width=640&amp;height=550&amp;TB_iframe=true');
      return false;           
    });


    // Video

    jQuery('#upload_image_button_homeland_svideo').click(function() {
      formfield_video = jQuery('#homeland_video').attr('name');
      tb_show('', 'media-upload.php?type=video&amp;width=640&amp;height=550&amp;TB_iframe=true');
      return false;           
    }); 

  
  // Send Editor
  var original_send_to_editor = window.send_to_editor;
  window.send_to_editor = function(html) {

  // Image . Video . Audio

    if(formfield) {
      var fileurl = jQuery(html).attr('src');
      if (typeof(fileurl)==="undefined") {
          fileurl = jQuery('img',html).attr('src');
      }
      jQuery('#' + formfield).val(fileurl);
      tb_remove();
      formfield = '';
    }else if(formfield_video) {
      var fileurl_video = jQuery(html).attr('href');
      if (typeof(fileurl_video)==="undefined") {
          fileurl_video = jQuery('video',html).attr('src');
      }
      jQuery('#' + formfield_video).val(fileurl_video);
      tb_remove();
      formfield_video = '';
    }else if(formfield_audio) {
      var fileurl_audio = jQuery(html).attr('href');
      if (typeof(fileurl_audio)==="undefined") {
          fileurl_audio = jQuery('audio',html).attr('src');
      }
      jQuery('#' + formfield_audio).val(fileurl_audio);
      tb_remove();
      formfield_audio = '';
    }else {
      original_send_to_editor(html);
    }

  };
    
})(jQuery);