export class helperCore {
    public static encode(value: string): string {
        return btoa(value);
    }
    public static decode(value: string): string {
        return atob(value);
    }

}
