import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import LogoutButton from "../Authentication/Logout/Logout";

const Profile = () => {
    const {user, isAuthenticated, isLoading} = useAuth0();

    if(isLoading){
        return <div>Loading ...</div>
    }

    return(
        isAuthenticated && (
            <div>
                <img src={user?.picture} alt={user?.name}></img>
                <h2>{user?.name}</h2>
                <p>{user?.email}</p>
                <LogoutButton />
            </div>
        )
    
    )
};  

export default Profile;