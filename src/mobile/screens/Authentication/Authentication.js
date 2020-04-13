import React, { useState } from 'react';
import { StyleSheet, StatusBar, View, SafeAreaView, ImageBackground, Image } from 'react-native';
import { Text, Card, Layout, Input, Icon, Button, Divider } from '@ui-kitten/components';

const FacebookIcon = (props) => (
    <Icon {...props} name='facebook' />
);

const Authentication = () => {

    const [value, setValue] = React.useState('');

    return (
        <ImageBackground resizeMode='cover' source={require('../../assets/LoginBg.png')} style={styles.imageBg}>

            <View>
                <Button style={{ flexDirection: 'row-reverse', alignSelf: 'flex-end' }} appearance='ghost' status='basic'>Log in</Button>
                <Text category='h1' style={styles.headerText}>Find and book the best restaurants</Text>
            </View>

            <View style={styles.buttonsContainer}>
                <Button style={styles.button} status='success' size='medium'>Sign up</Button>
                <Text style={{ color: 'white', alignSelf: 'center' }}>OR</Text>
                <Button style={styles.button} status='basic' size='medium'>Continue with Apple</Button>
                <Button style={styles.button} status='primary' size='medium' icon={FacebookIcon}>Continue with Facebook</Button>
                <Text category='c2' style={{ color: 'white', textAlign: 'center' }}>By signing up you agree to our Terms of Use and Privacy Policy</Text>
            </View>

        </ImageBackground>
    )
}

const styles = StyleSheet.create({
    innerContainer: {
        alignItems: 'center',
        paddingTop: 170,
        paddingBottom: 25,
        backgroundColor: 'white',
        borderRadius: 25,
    },
    inputsConteiner: {
        marginTop: 10,
        marginBottom: 10,
        minWidth: 220
    },
    imageBg: {
        flex: 1,
        resizeMode: 'cover',
        justifyContent: 'space-between',
        padding: 25
    },
    headerText: {
        color: 'white',
        fontWeight: 'bold',
        marginBottom: 10,
        alignSelf: 'flex-start',
    },
    buttonsContainer: {
        flexDirection: 'column',
        justifyContent: "space-between",
        marginTop: 20,
    },
    button: {
        paddingLeft: 30,
        paddingRight: 30,
        borderRadius: 12,
        margin: 0,
        marginBottom: 10,
        marginTop: 10
    },
    enterButton: {
        paddingLeft: 20,
        paddingRight: 20
    }
})

const abstractStyles = StyleSheet.create({
    top: {
        height: 10,
        borderBottomLeftRadius: 20,
        borderBottomRightRadius: 20,
        backgroundColor: 'rgba(255,255,255,0.8)',
        marginLeft: 20,
        marginRight: 20
    },
    bottom: {
        height: 10,
        borderBottomLeftRadius: 20,
        borderBottomRightRadius: 20,
        backgroundColor: 'rgba(255,255,255,0.5)',
        marginLeft: 40,
        marginRight: 40
    }
})

export default Authentication