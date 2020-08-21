import React from "react";
import AsyncStorage from "@react-native-community/async-storage";
import { authorize } from "react-native-app-auth";
import { createStackNavigator } from "@react-navigation/stack";
import Authentication from "../screens/Authentication/Authentication";
import { CreateAccount, Splash } from "../screens/Screens";
import { NavigationContainer } from "@react-navigation/native";
import openIdConfig from "../openIdConfig";
import log from "../log";

// Create Context Object
export const AuthContext = React.createContext();

const AuthStack = createStackNavigator();
const AuthStackScreen = () => (
    <AuthStack.Navigator>
        <AuthStack.Screen
            name="Authentication"
            component={Authentication}
            options={{ headerShown: false }}
        />
        <AuthStack.Screen
            name="CreateAccount"
            component={CreateAccount}
            options={{ title: "Create Account" }}
        />
    </AuthStack.Navigator>
);

export const AuthContextProvider = props => {
    const [isLoading, setIsLoading] = React.useState(true);
    const [token, setToken] = React.useState(null);

    const setNewToken = (token) => {
        setToken(token)
        setIsLoading(false)
    }

    React.useEffect(() => { AsyncStorage.getItem('token').then(data => setNewToken(data)) }, [])

    const context = React.useMemo(() => {
        return {    
            signIn: async () => {
                setIsLoading(true)
                authorize(openIdConfig).then(result => {
                    AsyncStorage.setItem('token', result.accessToken).then(() => {
                        setNewToken(result.accessToken)
                    })
                })
            },
            signUp: () => {
                setToken("asdf");
            },
            signOut: () => {
                setToken(null);

                revoke(openIdConfig, { tokenToRevoke: token })
            },
            getToken: () => token,
        };
    }, []);

    if (isLoading) {
        return <Splash />;
    }

    return (
        <AuthContext.Provider value={context}>
            <NavigationContainer>
                {token ? props.children :
                    <AuthStackScreen />}
            </NavigationContainer>
        </AuthContext.Provider>
    );
};