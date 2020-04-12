import React, { useState } from 'react';
import { StyleSheet, StatusBar, View, SafeAreaView, ImageBackground, Image } from 'react-native';
import { Text, Card, Layout, Input, Icon, Button, Divider } from '@ui-kitten/components';

const StarIcon = (props) => (
    <Icon {...props} name='arrow-forward-outline' />
);

const GoogleIcon = (props) => (
    <Icon {...props} name='google' />
);

const FacebookIcon = (props) => (
    <Icon {...props} name='facebook' />
);

const SignUp = () => {

    const [value, setValue] = React.useState('');

    return (
        <ImageBackground resizeMode='cover' source={require('../../assets/LoginBg.png')} style={styles.imageBg}>
            <Text category='h1' style={styles.headerText}>Sign Up</Text>
            <View style={styles.innerContainer}>
                <Text category='h2'>Join Us</Text>
                <Text category='s2'>We would love you to join us</Text>
                <View style={styles.socialButtonsContainer}>
                    <Button appearance='outline' status='danger' icon={GoogleIcon} size='small' />
                    <Button appearance='outline' icon={FacebookIcon} size='small' />
                </View>
                <Text style={styles.textUnderSocials} category='s2'>We have multiple options for you to join us</Text>

                <View style={styles.inputsConteiner}>
                    <Input size='small' placeholder='Name Or Username' value={value} onChangeText={nextValue => setValue(nextValue)} />
                    <Input size='small' placeholder='Email' value={value} onChangeText={nextValue => setValue(nextValue)} />
                    <Input size='small' placeholder='*****************' value={value} onChangeText={nextValue => setValue(nextValue)} />
                </View>

                <Button style={styles.enterButton} size='small' icon={StarIcon} />
            </View>
            <View style={abstractStyles.top}></View>
            <View style={abstractStyles.bottom}></View>

            <View style={styles.buttonsContainer}>
                <Button style={styles.button} status='basic' size='large'>Sign In</Button>
                <Button style={styles.button} size='large'>Sign Up</Button>
            </View>
        </ImageBackground>
    )
}

const styles = StyleSheet.create({
    innerContainer: {
        alignItems: 'center',
        paddingTop: 25,
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
        paddingLeft: 25,
        paddingRight: 25,
        paddingTop: 80
    },
    imageBgInner: {
        borderRadius: 25
    },
    headerText: {
        color: 'white',
        fontWeight: 'bold',
        marginBottom: 10
    },
    buttonsContainer: {
        flexDirection: 'row',
        justifyContent: "space-between",
        marginTop: 20,
    },
    button: {
        paddingLeft: 30,
        paddingRight: 30,
        borderRadius: 12,
        margin: 0
    },
    socialButtonsContainer: {
        flexDirection: 'row',
        justifyContent: "space-evenly",
        marginTop: 20,
        minWidth: 200
    },
    textUnderSocials: {
        marginTop: 15
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

export default SignUp