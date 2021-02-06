export function curDateTemplate() {
    let years = new Date().getFullYear();
    let months = new Date().getMonth();
    let days = new Date().getDate();
    let hours = new Date().getHours();
    let minutes = new Date().getMinutes();

    let monthsPart = months + 1 < 10 ? `0${months + 1}` : months + 1;
    let daysPart = days < 10 ? `0${days}` : days;
    let hoursPart = hours < 10 ? `0${hours}` : hours;
    let minutesPart = minutes < 10 ? `0${minutes}` : minutes;

    let curDate = `${years}-${monthsPart}-${daysPart}T${hoursPart}:${minutesPart}:00.000`;

    return curDate;
}

export function curOnlyDateTemplate() {
    let years = new Date().getFullYear();
    let months = new Date().getMonth();
    let days = new Date().getDate();

    let monthsPart = months + 1 < 10 ? `0${months + 1}` : months + 1;
    let daysPart = days < 10 ? `0${days}` : days;

    let curDate = `${years}-${monthsPart}-${daysPart}`;

    return curDate;
}