
export function isTokenExpired() {
    let exp = localStorage.exp;
    let expDate = new Date(exp * 1000 - 30 * 1000);
    
    return expDate < new Date();
}

export function logOut() {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('login');
    localStorage.removeItem('username');
    localStorage.removeItem('roles');
    localStorage.removeItem('exp');
}

export function getAccessToken() {
    return localStorage.getItem('accessToken');
}

export function setAuth(data) {
    localStorage.setItem('accessToken', data.token);
    localStorage.setItem('login', data.login);
    localStorage.setItem('username', data.name);
    localStorage.setItem('roles', JSON.stringify(data.roles));
    let exp = JSON.parse(atob(data.token.split('.')[1])).exp;
    localStorage.setItem('exp', exp);
}