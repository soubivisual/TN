// -----------------------------------------------------------------------
// -- Template
// -----------------------------------------------------------------------

function ToggleFullScreen() {
    var a = $(window).height() - 10;

    if (!document.fullscreenElement && // alternative standard method
        !document.mozFullScreenElement && !document.webkitFullscreenElement) { // current working methods
        if (document.documentElement.requestFullscreen) {
            document.documentElement.requestFullscreen();
        } else if (document.documentElement.mozRequestFullScreen) {
            document.documentElement.mozRequestFullScreen();
        } else if (document.documentElement.webkitRequestFullscreen) {
            document.documentElement.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
        }
    } else {
        if (document.cancelFullScreen) {
            document.cancelFullScreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitCancelFullScreen) {
            document.webkitCancelFullScreen();
        }
    }

    $('.full-screen > a > i').toggleClass('icon-maximize');
    $('.full-screen > a > i').toggleClass('icon-minimize');
}

function ToggleMenu() {
    if ($('.navbar').hasClass('show')) {
        $('.navbar').addClass('hide');
        $('.navbar').removeClass('show');
    }
    else {
        $('.navbar').addClass('show');
        $('.navbar').removeClass('hide');
    }
}

function SlideToggleMenuItem(id) {
    $('.nav-item.nav-item-hasmenu').each(function (index) {
        if ($(this).children('#' + id).length)
            $(this).children('.nav-submenu').stop().slideToggle(300);
        else
            if (!$(this).children('.nav-submenu').has('#' + id).length) // Si se está abriendo un submenú dentro de otro submenú, no se cierra
                $(this).children('.nav-submenu').slideUp(300);
    })
}

function ResetSlideToggleMenuItem() {
    $('.nav-submenu').each(function (index) {
        $(this).removeAttr("style"); // Se quita el estilo de los submenus para evitar que cuando se redireccione a una página un submenú previo quede visible
    });
}

// -----------------------------------------------------------------------
// -- Modals
// -----------------------------------------------------------------------

function ShowModal(modalSelector, dismisable) {
    if (!dismisable)
        $(modalSelector).modal({ backdrop: 'static', keyboard: false }, 'show'); // Prevent outside click or escape button
    else
        $(modalSelector).modal('show');
}

function HideModal(modalSelector) {
    $(modalSelector).modal('hide');
}

// -----------------------------------------------------------------------
// -- Session Storage
// -----------------------------------------------------------------------

function SetInSessionStorage(key, value) {
    sessionStorage.setItem(key, JSON.stringify(value));
}

function GetFromSessionStorage(key) {
    return JSON.parse(sessionStorage.getItem(key));
}

function RemoveFromSessionStorage(key) {
    sessionStorage.removeItem(key);
}

// -----------------------------------------------------------------------
// -- Local Storage
// -----------------------------------------------------------------------

function SetInLocalStorage(key, value) {
    localStorage.setItem(key, JSON.stringify(value));
}

function GetFromLocalStorage(key) {
    return JSON.parse(localStorage.getItem(key));
}

function RemoveFromLocalStorage(key) {
    localStorage.removeItem(key);
}