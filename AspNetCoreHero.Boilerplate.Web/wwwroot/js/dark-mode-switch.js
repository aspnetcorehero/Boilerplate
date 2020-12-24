const darkSwitch = document.getElementById('darkSwitch');
window.addEventListener('load', () => {
    if (darkSwitch) {
        initTheme();
        darkSwitch.addEventListener('change', () => {
            resetTheme();
        });
    }
});

/**
 * Summary: function that adds or removes the attribute 'data-theme' depending if
 * the switch is 'on' or 'off'.
 *
 * Description: initTheme is a function that uses localStorage from JavaScript DOM,
 * to store the value of the HTML switch. If the switch was already switched to
 * 'on' it will set an HTML attribute to the body named: 'data-theme' to a 'dark'
 * value. If it is the first time opening the page, or if the switch was off the
 * 'data-theme' attribute will not be set.
 * @return {void}
 */
function initTheme() {
    const darkThemeSelected =
        localStorage.getItem('darkSwitch') !== null &&
        localStorage.getItem('darkSwitch') === 'dark';
    darkSwitch.checked = darkThemeSelected;
    if (darkThemeSelected) {
        document.body.setAttribute('data-theme', 'dark');
        $('#navigationBar').addClass('navbar-dark').removeClass('navbar-light');
        $('#sideBar').addClass('sidebar-dark-primary').removeClass('sidebar-light-primary');
        $('.content-wrapper').attr('style', 'background-color: #111');
        $('.card').attr('style', 'background-color: #212121');
        $('.main-footer').attr('style', 'background-color: #212121');
        $('.form-control').attr('style', 'background-color: #212121!important;color:white;border:1px solid #3c3c3c');
        $('.modal-content').attr('style', 'background-color: #212121!important;');
        $('.loader-section').attr('style', 'background: #212121!important;');
        $("#brand-logo").attr("src", "/images/logo-transparent-light.png");
        //.form-control
    }
    else {
        document.body.removeAttribute('data-theme');
        $('#sideBar').addClass('sidebar-light-primary').removeClass('sidebar-dark-primary');
        $('#navigationBar').removeClass('navbar-dark').addClass('navbar-light');
        $('.content-wrapper').attr('style', 'background-color: #f4f6f9');
        $('.card').attr('style', 'background-color: #ffffff');
        $('.main-footer').attr('style', 'background-color: #ffffff');
        $('.form-control').attr('style', 'background-color: #ffffff!important;color:black;border:1px solid #ced4da');
        $('.modal-content').attr('style', 'background-color: #ffffff!important;');
        $('.loader-section').attr('style', 'background: #ffffff!important;');
        $("#brand-logo").attr("src", "/images/logo-transparent-dark.png");
    }
}

/**
 * Summary: resetTheme checks if the switch is 'on' or 'off' and if it is toggled
 * on it will set the HTML attribute 'data-theme' to dark so the dark-theme CSS is
 * applied.
 * @return {void}
 */
function resetTheme() {
    if (darkSwitch.checked) {
        document.body.setAttribute('data-theme', 'dark');
        $('#sideBar').addClass('sidebar-dark-primary').removeClass('sidebar-light-primary');
        $('#navigationBar').addClass('navbar-dark').removeClass('navbar-light');
        $('.content-wrapper').attr('style', 'background-color: #111');
        $('.card').attr('style', 'background-color: #212121');
        $('.main-footer').attr('style', 'background-color: #212121');
        $('.form-control').attr('style', 'background-color: #212121!important;color:white;border:1px solid #3c3c3c');
        $('.modal-content').attr('style', 'background-color: #212121!important;');
        $('.loader-section').attr('style', 'background: #212121!important;');
        $("#brand-logo").attr("src", "/images/logo-transparent-light.png");
        localStorage.setItem('darkSwitch', 'dark');
    } else {
        document.body.removeAttribute('data-theme');
        $('#sideBar').addClass('sidebar-light-primary').removeClass('sidebar-dark-primary');
        $('#navigationBar').removeClass('navbar-dark').addClass('navbar-light');
        $('.content-wrapper').attr('style', 'background-color: #f4f6f9');
        $('.card').attr('style', 'background-color: ##ffffff');
        $('.main-footer').attr('style', 'background-color: #ffffff');
        $('.form-control').attr('style', 'background-color: #ffffff!important;color:black;border:1px solid #ced4da');
        $('.modal-content').attr('style', 'background-color: #ffffff!important;');
        $('.loader-section').attr('style', 'background: #ffffff!important;');
        $("#brand-logo").attr("src", "/images/logo-transparent-dark.png");
        localStorage.removeItem('darkSwitch');
    }
}