export interface UserDto {
    loginName?: string;
    fullName?: string;
    status?: boolean;
    password?: string;
    role?: number;  
    createDate?: string;
    facultyID?: string;
    oldPassword?: string; // Added property for old password
    newPassword?: string;
}