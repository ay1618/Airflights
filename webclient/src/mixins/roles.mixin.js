export default {
    computed: {
        roles: () => {
            if (localStorage.roles) {
                return JSON.parse(localStorage.roles);
            }
            return null;
        },
        isAdmin() {
            return this.roles && this.roles.some(x => x === 'ADM');
        },
        isModerator() {
            return this.roles && this.roles.some(x => x === 'MOD');
        }

    }
}