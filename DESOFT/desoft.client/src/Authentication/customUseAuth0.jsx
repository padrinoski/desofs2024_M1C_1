import {useEffect, useState} from 'react';
import {useAuth0} from '@auth0/auth0-react';
import axios from 'axios';

const customUseAuth0 = () => {
    const {user, isAuthenticated, isLoading,getAccessTokenSilently,loginWithRedirect} = useAuth0();
    const [userInfo, setUserInfo] = useState(null);
    const [isUserChecked, setIsUserChecked] = useState(false);

    useEffect(() => {
        const checkAndCreateUser = async () => {
            if (isAuthenticated && user) {
                const id = user?.sub;
                const domain = "localhost:5265";


                try {

                    const accessToken = await getAccessTokenSilently({
                        authorizationParams: {
                            audience: `http://${domain}`,
                        },
                    })

                    console.log(accessToken);

                    console.log("\nAccess Token: " + accessToken)
                    const getUserByIdUrl = (`http://${domain}/api/Users/${user?.sub}`);

                    const metadataResponse = await fetch(getUserByIdUrl, {
                        headers: {
                            Authorization: `Bearer ${accessToken}`,
    
                        },
                    });

                    const {data} =  await metadataResponse.json();

                    if (data !== null && data.userId === id) {
                        setUserInfo(data);
                    } else {
                        const newUser = {
                            UserId: user.sub,
                            Username: user.name,
                            Address: user.email,
                            Password: "authenticated_by_auth0",
                        };

                        console.log(JSON.stringify(newUser));

                        const createUser = (`http://${domain}/api/Users/CreateUser`);

                        const createResponse = await fetch(createUser, {
                            method: 'POST',
                            headers:{
                                'content-type': 'application/json',
                                Authorization: `Bearer ${accessToken}`,
                            },
                            body: JSON.stringify(newUser)
                        });
                                        
                        console.log(createResponse);

                        setUserInfo(createResponse.data);
                    }
                } catch (e) {
                    if (e.error === 'consent_required') {
                        loginWithRedirect({
                            authorizationParams: {
                                audience: `http://${domain}`,
                                prompt: 'consent',
                            },
                        });
                    }else{
                        console.error("Error checking or creating user:", e);
                    }

                } finally {
                    setIsUserChecked(true);
                }
            }
        };

        if (!isLoading && !isUserChecked) {
            checkAndCreateUser();
        }
    }, [isAuthenticated, isLoading, user, isUserChecked]);

    return {userInfo, isAuthenticated, isLoading};
};

export default customUseAuth0;
