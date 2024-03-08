
// var apiUrl = 'http://localhost:5000';
var apiUrl = 'http://localhost:30428';

// var headers = {
//     'MenuName': encodeURI(document.title),
//     'ClientType': '1',
//     'Authorization': 'Bearer ' + $.cookie('Authorization')
// };

// ajax通用配置
$.ajaxSetup({
    cache: false,
    // headers: headers,
    // crossDomain: true,  
    // crossOrigin: true, // http://www.ajax-cross-origin.com/install.html
    error: function(rep) {
        if (rep.status == 401) {
            //top.location.href = "login.html" ;
            return;
        }
        
        if (rep.status == 0) {
            return;
        }

        Swal.fire({
            icon: 'error',
            title: '系统异常',
            html: '<div style="text-align: left; height: 300px; font-size: 9px; white-space: pre-wrap;">' + rep.responseText + '</div>',
            buttonsStyling: false,
            confirmButtonText: "确定",
            customClass: {
                confirmButton: "btn btn-primary"
            },
            hideClass: {
                popup: 'animate__animated animate__fadeOutUp'
            }
        });
    }
});

 // 获取URL参数
 function getUrlParameter(name)
 {
      name = name.replace(/[]/,"\[").replace(/[]/,"\[").replace(/[]/,"\\\]");
      var regexS = "[\\?&]" + name + "=([^&#]*)";
      var regex = new RegExp( regexS );
      var results = regex.exec(window.parent.location.href);
      if( results == null ) 
      {
          return ""; 
      }
      else 
      {
          return results[1];
      }
}

// 是否为空字符串
function isEmpty(val) {
    if(val != null && val != "null" && val != "" && val != undefined)
    {
        if (typeof val == 'string') {
            if(val.trim() == "") {
                return true;
            }
        }
        return false;
    }
    else {
        return true;
    }
}

// 空值处理，借鉴Oracle Nvl函数
// 如果val1为空字符串，则函数返回val2，否则返回val1本身。
function Nvl(val1, val2) {
    return isEmpty(val1) ? val2: val1;
}

// 显示成功消息
function showSuccessMsg(message, callback){
    Swal.fire({
        icon: "success",
        title: message,
        buttonsStyling: false,
        confirmButtonText: "确定",
        customClass: {
            confirmButton: "btn btn-primary"
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            if(callback != null) {
                callback();
            }
        }
    });  
}

// 显示信息消息
function showInfoMsg(message, callback){
    Swal.fire({
        icon: "info",
        title: message,
        buttonsStyling: false,
        confirmButtonText: "确定",
        customClass: {
            confirmButton: "btn btn-primary"
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            if(callback != null) {
                callback();
            }
        }
    });  
}

// 显示报警消息
function showWarningMsg(message, callback){
    Swal.fire({
        icon: "warning",
        title: message,
        buttonsStyling: false,
        confirmButtonText: "确定",
        customClass: {
            confirmButton: "btn btn-primary"
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            if(callback != null) {
                callback();
            }
        }
    });  
}

// 显示错误消息
function showErrorMsg(message, callback){
    Swal.fire({
        icon: "error",
        title: message,
        buttonsStyling: false,
        confirmButtonText: "确定",
        customClass: {
            confirmButton: "btn btn-primary"
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            if(callback != null) {
                callback();
            }
        }
    });  
}