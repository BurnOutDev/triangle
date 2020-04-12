import React, { useState } from 'react';
import { StyleSheet, StatusBar, View, SafeAreaView, ImageBackground, Image } from 'react-native';
import { Text, Card, Layout, Input, Icon, Button, Divider } from '@ui-kitten/components';

const StarIcon = (props) => (
    <Icon {...props} name='arrow-forward-outline' />
);

const SignIn = () => {

    const [value, setValue] = React.useState('');

    return (
        <ImageBackground resizeMode='cover' source={require('../../assets/LoginBg.png')} style={styles.imageBg}>
            <Text category='h1' style={styles.headerText}>Sign In</Text>
            <ImageBackground resizeMode='cover' source={require('../../assets/LoginBgInner.png')} style={styles.innerContainer} imageStyle={styles.imageBgInner}>
                {/* <Image style={styles.imageBgInner} source={require('../../assets/LoginBgInner.png')} /> */}
                <Text category='h2'>Welcome Back</Text>
                <Text category='s2'>We Love to see you again</Text>

                <View style={styles.inputsConteiner}>
                    <Input size='small' placeholder='Username Or Email Address' value={value} onChangeText={nextValue => setValue(nextValue)} />
                    <Input size='small' placeholder='*****************' value={value} onChangeText={nextValue => setValue(nextValue)} />
                </View>

                <Button size='small' icon={StarIcon} />
            </ImageBackground>
            <View style={abstractStyles.top}></View>
            <View style={abstractStyles.bottom}></View>

            <View style={styles.buttonsContainer}>
                <Button style={styles.button} size='large'>Sign In</Button>
                <Button style={styles.button} status='basic' size='large'>Sign Up</Button>
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

export default SignIn