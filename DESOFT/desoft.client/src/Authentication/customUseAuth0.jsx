import {useEffect, useState} from 'react';
import {useAuth0} from '@auth0/auth0-react';
import axios from 'axios';

const customUseAuth0 = () => {
    const {user, isAuthenticated, isLoading} = useAuth0();
    const [userInfo, setUserInfo] = useState(null);
    const [isUserChecked, setIsUserChecked] = useState(false);

    useEffect(() => {
        const checkAndCreateUser = async () => {
            if (isAuthenticated && user) {
                const username = user.nickname || user.name;

                try {
                    const response = await axios.get(`http://localhost:5265/api/Users/GetUserByUsername/${username}`);

                    if (response.data.data !== null && response.data.data.username === username) {
                        console.log("User exists");
                        setUserInfo(response.data.data);
                        console.log(response.data.data.userId);
                    } else {
                        console.log("User doesn't exist - creating it");
                        console.log(user.sub);
                        // Neste newUser tens que guardar o userId como user.sub, mas só qd mudares o modelo de dadaos
                        const newUser = {
                            //userId: user.sub,
                            username: username,
                            address: username,
                            password: "authenticated_by_auth0",
                        };

                        const createResponse = await axios.post(`http://localhost:5265/api/Users/CreateUser`, newUser);
                        setUserInfo(createResponse.data);
                        console.log("User Created successfully");
                    }
                } catch (error) {
                    console.error("Error checking or creating user:", error);
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
