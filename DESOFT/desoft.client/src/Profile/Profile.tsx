import { useAuth0 } from "@auth0/auth0-react";
import { useEffect} from "react"
import { useState } from "react";

const Profile = () => {
    const {user, isAuthenticated, isLoading, getAccessTokenSilently} = useAuth0();
    const [userMetadata, setUserMetadata] = useState(null);

    useEffect(() => {
        const getUserMetadata = async () => {
            const domain = "localhost:5265";
            
            try{
                const accessToken = await getAccessTokenSilently({
                    authorizationParams: {
                        audience: `http://${domain}`,
                    },
                })
                console.log("\nAccess Token: " + accessToken)
                const userDetailsByIdUrl = (`http://${domain}/api/Users/6`);

                console.log("\nUser Details By Id Url: " + userDetailsByIdUrl)

                const metadataResponse = await fetch(userDetailsByIdUrl, {
                    headers: {
                        Authorization: `Bearer ${accessToken}`,

                    },
                });

                const {data} =  await metadataResponse.json();

                setUserMetadata(data);

            } catch(e){
                console.log(e);
            }
        };
        if (user && isAuthenticated) {
            getUserMetadata();
        }

    }, [user, getAccessTokenSilently]);


    if(isLoading){
        return <div>Loading ...</div>
    }


    return(
        isAuthenticated && (
            <div>
                <img src={user?.picture} alt={user?.name}></img>
                <h2>{user?.name}</h2>
                <p>{user?.email}</p>
                <p>{user?.roles}</p>
                <h3>User Metadata</h3>
                {userMetadata ? (<pre>{JSON.stringify(userMetadata, null, 2)}</pre>):("No User Metadata defined")}
            </div>
        )
    
    )
};  

export default Profile;