// -----------------------------------------------------------------------
// -- Template
// -----------------------------------------------------------------------

function ToggleFullScreen() {
    var a = window.innerHeight - 10;

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

    var fullScreenLinks = document.querySelectorAll('.full-screen > a > i');
    fullScreenLinks.forEach(function (link) {
        link.classList.toggle('icon-maximize');
        link.classList.toggle('icon-minimize');
    });
}

function ToggleMenu() {
    var navbar = document.querySelector('.navbar');
    console.log('in toogle 0');

    if (navbar.classList.contains('show')) {
        navbar.classList.add('hide');
        navbar.classList.remove('show');
    } else {
        navbar.classList.add('show');
        navbar.classList.remove('hide');
    }
}

function SlideToggleMenuItem(id) {
    document.querySelectorAll('.nav-item.nav-item-hasmenu').forEach(function (navItem, index) {

        if (navItem.querySelector('#' + id)) {
            navItem.querySelector('.nav-submenu').style.display = 'none';
            setTimeout(function () {
                navItem.querySelector('.nav-submenu').style.display = 'block';
            }, 300);
        } else {
            if (!navItem.querySelector('.nav-submenu').querySelector('#' + id)) {
                navItem.querySelector('.nav-submenu').style.display = 'block';
                setTimeout(function () {
                    navItem.querySelector('.nav-submenu').style.display = 'none';
                }, 300);
            }
        }
    });
}

function ResetSlideToggleMenuItem() {
    console.log('in toogle2');

    document.querySelectorAll('.nav-submenu').forEach(function (navSubmenu, index) {
        navSubmenu.removeAttribute("style");  // Se quita el estilo de los submenus para evitar que cuando se redireccione a una página un submenú previo quede visible
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

// -----------------------------------------------------------------------
// -- Toggle Tooltip
// -----------------------------------------------------------------------
function LoadTNTooltip(position) {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[tntooltip-title]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        let title = tooltipTriggerEl.getAttribute('tntooltip-title');
        tooltipTriggerEl.setAttribute('title', title);

        if (tooltipTriggerEl.hasAttribute('tntooltip-position')) {
            let tooltipPosition = tooltipTriggerEl.getAttribute('tntooltip-position');
            position = tooltipPosition;
        }
        tooltipTriggerEl.setAttribute('data-bs-placement', position);

        return new bootstrap.Tooltip(tooltipTriggerEl)
    })
}


// -----------------------------------------------------------------------
// -- Toggle Popover
// -----------------------------------------------------------------------

function LoadTNPopover(position) {
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[tnpopover-title]'))
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        let title = popoverTriggerEl.getAttribute('tnpopover-title');

        if (popoverTriggerEl.hasAttribute('tnpopover-content')) {
            let content = popoverTriggerEl.getAttribute('tnpopover-content');
            popoverTriggerEl.setAttribute('data-bs-content', content);
        }
        if (popoverTriggerEl.hasAttribute('tnpopover-position')) {
            let popoverPosition = popoverTriggerEl.getAttribute('tnpopover-position');
            position = popoverPosition;
        }
        popoverTriggerEl.setAttribute('data-bs-toggle', 'popover');
        popoverTriggerEl.setAttribute('data-bs-placement', position);
        popoverTriggerEl.setAttribute('title', title);

        popoverTriggerEl.setAttribute('data-bs-trigger', 'focus');
        return new bootstrap.Popover(popoverTriggerEl, {trigger: 'focus'})
    })
}

// -----------------------------------------------------------------------
// -- ETC
// -----------------------------------------------------------------------


function AddEventListener(id, eventName, script) {
    $('#' + id + ':not(.event-listener-attached)')
        .addClass('event-listener-attached')
        .on(eventName, function () {
            eval(script);
        });
}

function ScrollPosition(x, y) {
    window.scrollTo(x, y);
}

function IsMobile() {
    return /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent);
}



// -----------------------------------------------------------------------
// -- Easepick js 
// -----------------------------------------------------------------------

//Variables para el uso de rango de fechas
let beginDate;
let endDate;

//Crea el componente de calendario para las fechas
function CreateDatePicker(elementId, format, minimumDate, maximumDate, isRangeDate, isBeginDate) {
    let DatePicker = new easepick.create({
        element: document.getElementById(elementId),
        css: [
            '_content/TN.Client.Components.Shared/assets/plugins/easepick/base.css',
            '_content/TN.Client.Components.Shared/assets/plugins/easepick/lock.css'
        ],
        readonly: false,
        setup(DatePicker) {
            DatePicker.on('select', (e) => {
                const { date } = e.detail;
                let dateBinding = document.getElementById(elementId);
                let dateFormated = DateFormat(e.detail.date, format);
                dateBinding.value = dateFormated;
                BindBlazorProperty(elementId);
            });
        },
        format: format,
        plugins: ['LockPlugin'],
        LockPlugin: {
            minDate: minimumDate,
            maxDate: maximumDate
        },
    });
    if (isRangeDate) {
        if (isBeginDate) {
            beginDate = DatePicker;
        } else {
            endDate = DatePicker;
        }
    }
}

//Asigna la fecha minima del componente de calendario con rango de fechas
function DateTimePickerMinDate(selectedDate, date, format) {
    console.log('DateTimePickerMinDate', selectedDate);

    let selectedDateFormat = new easepick.DateTime(selectedDate, format);
    let dateFormat = new easepick.DateTime(date, format);

    const lockPlugin = beginDate.PluginManager.getInstance('LockPlugin');
    lockPlugin.options.maxDate = dateFormat;
    console.log(lockPlugin);
    beginDate.renderAll();

    const lockPluginEnd = endDate;
    console.log(lockPluginEnd);
    lockPluginEnd.options.date = dateFormat;
    endDate.renderAll();
}

//Asigna la fecha maxima del componente de calendario con rango de fechas
function DateTimePickerMaxDate(selectedDate, date, format) {
    console.log('DateTimePickerMaxDate', selectedDate);
    let selectedDateFormat = new easepick.DateTime(selectedDate, format);
    let dateFormat = new easepick.DateTime(date, format);

    const lockPlugin = endDate.PluginManager.getInstance('LockPlugin');
    lockPlugin.options.minDate = dateFormat;
    endDate.renderAll();

    const lockPluginBegin = beginDate;
    console.log(lockPluginBegin);

    lockPluginBegin.options.date = dateFormat;
    beginDate.renderAll();
}


//Crea el componente de calendario con rango de fechas en un mism componente
function CreateDateRange(elementId) {
    let DateRangePicker = new easepick.create({
        element: document.getElementById(elementId),
        css: [
            '_content/TN.Client.Components.Shared/assets/plugins/easepick/base.css',
            '_content/TN.Client.Components.Shared/assets/plugins/easepick/range.css',
        ],
        plugins: ['RangePlugin'],
        RangePlugin: {
            tooltip: true,
        },
        elementEnd: document.getElementById('dateCatcher'),
        zindex: 100,
        setup(DateRangePicker) {
            DateRangePicker.on('select', (e) => {
                dateCatcher = document.getElementById('dateCatcher');
                dateCatcher.value = e.detail.start.toLocaleDateString() + '-' + e.detail.end.toLocaleDateString();
                BindBlazorProperty('dateCatcher');
            });
        },

    });
}

// -----------------------------------------------------------------------
// -- Blazor
// -----------------------------------------------------------------------

// Cambiar un valor desde Javascript y que modifique la propiedad bind en blazor:
function BindBlazorProperty(id, value = null) {
    var element = document.getElementById(id);

    if (value !== null)
        element.value = value;

    var event = new Event('change');
    element.dispatchEvent(event);
}

// -----------------------------------------------------------------------
// -- DateFormat
// -----------------------------------------------------------------------

// Cambia el formato de la fecha
function DateFormat(date, dateFormat) {
    if (dateFormat == 'YYYY-MM-DD') {
        let year = date.getFullYear();
        let month = (date.getMonth() + 1);
        let day = date.getDate();
        return year + "-" + (month < 10 ? `0${month}` : month) + "-" + (day < 10 ? `0${day}` : day);
    } else {
        return date;
    }
}


// -----------------------------------------------------------------------
// -- Choises JS
// -----------------------------------------------------------------------

// Crea el componente de busqueda para los combobox
function InitializeSelectChoices(id, isSearchEnabled, searchPlaceholder) {
    var element = document.getElementById(id);
    new Choices(element, {
        allowHTML: false,
        searchEnabled: isSearchEnabled,
        searchFields: ['label'],
        searchFloor: 0,

        placeholderValue: 'This is a placeholder set in the config',
        searchPlaceholderValue: searchPlaceholder,
    });
}

// -----------------------------------------------------------------------
// -- Vibrate
// -----------------------------------------------------------------------

// Si es un dispositivo mobile realiza la accion de vibrar mediante javascript
function Vibrate(seconds) {
    window.navigator.vibrate(seconds*1000)
}


// -----------------------------------------------------------------------
// -- Swal Alert
// -----------------------------------------------------------------------

function SwalConfirm(confirmTitle, confirmText, confirmButtonText, successTitle, successText, dotNetHelper, methodName, data) {
    Swal.fire({
        title: confirmTitle,
        text: confirmText,
        icon: 'question',
        showCancelButton: true,
        buttonsStyling: false, // para que no incluya las clases: swal2-confirm swal2-styled
        //confirmButtonColor: '#DD6B55',
        confirmButtonText: confirmButtonText,
        cancelButtonText: 'Cancelar',
        showLoaderOnConfirm: true,
        allowOutsideClick: false,
        allowEscapeKey: false,
        customClass: {
            //container: 'container-class',
            //popup: 'popup-class',
            //header: 'header-class',
            //title: 'title-class',
            //closeButton: 'close-button-class',
            //icon: 'icon-class',
            //image: 'image-class',
            //content: 'content-class',
            //input: 'input-class',
            //actions: 'actions-class',
            confirmButton: 'col-5 btn btn-primary',
            cancelButton: 'col-5 btn btn-light mr-3',
            //footer: 'footer-class'
        },
        preConfirm: async () => {
            if (dotNetHelper) {
                await dotNetHelper.invokeMethodAsync(methodName, data).then(result => {
                    if (result === null)
                        SwalSuccess(successTitle, successText, 'Aceptar');
                    else //if (result.dismiss === Swal.DismissReason.cancel)
                        SwalError('Error', result, 'Aceptar');
                });
            }
        }
    });
}

async function SwalConfirmTransaction(confirmTitle, confirmText, confirmButtonText) {
    return await Swal.fire({
        title: confirmTitle,
        text: confirmText,
        icon: 'question',
        showCancelButton: true,
        buttonsStyling: false, // para que no incluya las clases: swal2-confirm swal2-styled
        //confirmButtonColor: '#DD6B55',
        confirmButtonText: confirmButtonText,
        cancelButtonText: 'Cancelar',
        showLoaderOnConfirm: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        customClass: {
            confirmButton: 'col-5 btn btn-primary',
            cancelButton: 'col-5 btn btn-light mr-3'
        }
    }).then((result) => {
        if (result.value)
            return true;
        else
            return false;
    });
}

function SwalInfo(title, text, confirmButtonText, dotNetHelper, methodName, data) {
    Swal.fire({
        title: title,
        text: text,
        icon: 'info',
        buttonsStyling: false,
        confirmButtonText: confirmButtonText,
        customClass: {
            confirmButton: 'btn btn-primary'
        }
    }).then(async (result) => {
        if (result.value)
            if (dotNetHelper)
                await dotNetHelper.invokeMethodAsync(methodName, data);
    });
}

function SwalSuccess(title, text, confirmButtonText, dotNetHelper, methodName, data) {
    Swal.fire({
        title: title,
        text: text,
        icon: 'success',
        buttonsStyling: false,
        confirmButtonText: confirmButtonText,
        customClass: {
            confirmButton: 'btn btn-primary'
        }
    }).then(async (result) => {
        if (result.value)
            if (dotNetHelper)
                await dotNetHelper.invokeMethodAsync(methodName, data);
    });
}

function SwalWarning(title, text, confirmButtonText, dotNetHelper, methodName, data) {
    Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        buttonsStyling: false,
        confirmButtonText: confirmButtonText,
        customClass: {
            confirmButton: 'btn btn-primary'
        }
    }).then(async (result) => {
        if (result.value)
            if (dotNetHelper)
                await dotNetHelper.invokeMethodAsync(methodName, data);
    });
}

function SwalError(title, text, confirmButtonText, dotNetHelper, methodName, data) {
    Swal.fire({
        title: title,
        text: text,
        icon: 'error',
        buttonsStyling: false,
        confirmButtonText: confirmButtonText,
        customClass: {
            confirmButton: 'btn btn-primary'
        }
    }).then(async (result) => {
        if (result.value)
            if (dotNetHelper)
                await dotNetHelper.invokeMethodAsync(methodName, data);
    });
}

function SwalException(title, text, code, type, uuid, timestamp, confirmButtonText, cancelButtonText, dotNetHelper, methodName, data, redirectUrl) {
    Swal.fire({
        title: title,
        html: text +
            '<div id="swalExceptionInfoButton" class="mt-4 mb-3"><a href="javascript:showSwalExceptionInfoButton();" style="text-decoration: underline;">Ver más información del Error</a></div>' +
            '<div id="swalExceptionInfo" class="mt-4 mb-3" style="display:none;">' +
            '<div>Code: ' + code + '</div>' +
            '<div>Type: ' + type + '</div>' +
            '<div>UUID: ' + uuid + '</div>' +
            '<div>Timestamp: ' + timestamp + '</div>' +
            '<div class="mt-4"><a href="javascript:hideSwalExceptionInfo();" style="text-decoration: underline;">Ver menos</a></div>' +
            '</div>',
        icon: 'warning',
        showCancelButton: cancelButtonText === null ? false : true,
        buttonsStyling: false,
        confirmButtonText: confirmButtonText,
        cancelButtonText: cancelButtonText,
        allowOutsideClick: false,
        allowEscapeKey: false,
        customClass: {
            confirmButton: 'col-5 btn btn-primary',
            cancelButton: 'col-5 btn btn-light mr-3'
        }
    }).then((result) => {
        if (result.value) {
            if (dotNetHelper)
                dotNetHelper.invokeMethodAsync(methodName, confirmButtonText, data);
        }
        else {
            if (dotNetHelper)
                dotNetHelper.invokeMethodAsync(methodName, cancelButtonText, redirectUrl);
        }
    });
}

function Swal2FA(title, text, confirmButtonText, cancelButtonText, dotNetHelper, methodName, data) {
    return new Promise(resolve => {
        Swal.fire({
            title: title,
            input: 'text',
            inputAttributes: {
                maxlength: '6',
                placeholder: 'OTP'
            },
            html: text,
            showCancelButton: true,
            buttonsStyling: false,
            confirmButtonText: confirmButtonText,
            cancelButtonText: cancelButtonText,
            showLoaderOnConfirm: true,
            allowOutsideClick: false,
            allowEscapeKey: false,
            customClass: {
                input: 'form-control',
                confirmButton: 'col-5 btn btn-primary',
                cancelButton: 'col-5 btn btn-light mr-3'
            },
            preConfirm: (token) => {
                if (token === "")
                    Swal.showValidationMessage('Por favor ingrese su OTP');
            }
        }).then(async (result) => {
            console.log(result);

            if (result.value !== undefined) {
                await dotNetHelper.invokeMethodAsync(methodName, result.value).then(result => {
                    if (result === null) {
                        resolve(true);
                    }
                    else {
                        SwalError('Error', result, 'Aceptar');
                        resolve(false);
                    }
                });
            }
            else {
                resolve(false);
            }
        }).catch(error => {
            console.log(error);
            Swal.showValidationMessage(`Hubo un error al validar el OTP: ${error}`);
        });
    });
}

function showSwalExceptionInfoButton() {
    $("#swalExceptionInfoButton").hide();
    $("#swalExceptionInfo").show();
}

function hideSwalExceptionInfo() {
    $("#swalExceptionInfoButton").show();
    $("#swalExceptionInfo").hide();
}

function SwalLogout(title, text, confirmButtonText) {
    Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        buttonsStyling: false,
        confirmButtonText: confirmButtonText,
        allowOutsideClick: false,
        allowEscapeKey: false,
        customClass: {
            confirmButton: 'btn btn-primary'
        }
    }).then(async (result) => {
        window.location.href = '/Logout';
    });
}

let map;
let script = document.createElement('script');
let currentLocation;
let locationMarkers;

function InitGoogleMaps(key) {
    script.src = `https://maps.googleapis.com/maps/api/js?key=${key}&callback=InitGoogleMap`;
    script.async = true;
    document.head.appendChild(script);
}

function CreateGoogleMap(key, location, locations) {
    currentLocation = { lat: location.latitude, lng: location.longitude };
    locationMarkers = locations;
    InitGoogleMaps(key);
}

function InitGoogleMap() {
    map = new google.maps.Map(document.getElementById("GoogleMap"), {
        center: currentLocation,
        zoom: 16,
        disableDefaultUI: true,
        zoomControl: true
    });
    SetGoogleMapMarkers();
}


function SetGoogleMapMarkers() {
    const infoWindow = new google.maps.InfoWindow();

    const currentLocationMarker = new google.maps.Marker({
        position: currentLocation,
        map,
        title: 'Ubicación actual',
        icon: {
            path: google.maps.SymbolPath.BACKWARD_CLOSED_ARROW,
            scale: 8,
            strokeColor: '#OOOOFF',
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: '#0000FF',
            fillOpacity: 0.5
        },
        optimized: false,
    });

    currentLocationMarker.addListener("click", () => {
        infoWindow.close();
        infoWindow.setContent(`<h4 id="firstHeading" class="firstHeading">Ubicación actual</h4>`);
        infoWindow.open(currentLocationMarker.getMap(), currentLocationMarker);
    });

    locationMarkers.forEach((item, i) => {
        const contentString =
            '<div id="content">' +
            '<div id="siteNotice">' +
            "</div>" +
            `<h4 id="firstHeading" class="firstHeading">${item.title}</h4>` +
            '<div id="bodyContent">' +
            `<p> ${item.content} </p>` +
            "</div>" +
            "</div>";    

        const marker = new google.maps.Marker({
            position: { lat: item.latitude, lng: item.longitude },
            map,
            title: `${i + 1}. ${item.title}`,
            optimized: false,
        });

        marker.addListener("click", () => {
            infoWindow.close();
            infoWindow.setContent(contentString);
            infoWindow.open(marker.getMap(), marker);
        });
    });
}

