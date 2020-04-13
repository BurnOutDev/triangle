import React, { useState } from 'react';
import { StyleSheet, StatusBar, View, SafeAreaView, ImageBackground, Image } from 'react-native';
import { Text, Card, Layout, Input, Icon, Button, Divider } from '@ui-kitten/components';
import { BlurView } from "@react-native-community/blur";

const ArrowIcon = (props) => (
    <Icon {...props} name='arrow-back' />
);

const SignUp = () => {

    const [email, setEmail] = React.useState('');
    const [password, setPassword] = React.useState('');

    return (
        <ImageBackground resizeMode='cover' source={require('../../assets/background.jpg')} style={styles.imageBg}>
            <BlurView blurAmount={10} style={styles.absolute}>
                <Button style={{ alignSelf: 'flex-start' }} appearance='ghost' status='basic' icon={ArrowIcon} />

                <Text category='h1' style={{ color: 'white', marginBottom: 30 }}>Sign up</Text>

                <View style={styles.buttonsContainer}>
                    <Input style={styles.input} placeholder='First Name' value={email} onChangeText={nextValue => setEmail(nextValue)} />
                    <Input style={styles.input} placeholder='Last Name' value={email} onChangeText={nextValue => setEmail(nextValue)} />
                    <Input style={styles.input} placeholder='Email' value={email} onChangeText={nextValue => setEmail(nextValue)} />
                    <Input style={styles.input} placeholder='Phone Number' value={email} onChangeText={nextValue => setEmail(nextValue)} />
                    <Input style={styles.input} placeholder='Password' value={password} onChangeText={nextValue => setPassword(nextValue)} />
                    <Button style={styles.button} status='success' size='medium'>Sign up</Button>
                </View>
            </BlurView>
        </ImageBackground>
    )
}

const styles = StyleSheet.create({
    imageBg: {
        flex: 1,
        resizeMode: 'cover'
    },
    headerText: {
        color: 'white',
        fontWeight: 'bold',
        marginBottom: 10,
        alignSelf: 'flex-start',
    },
    inputsContainer: {
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
    },
    input: {
        marginBottom: 10
    },
    absolute: {
        position: "absolute",
        top: 0,
        left: 0,
        bottom: 0,
        right: 0,
        padding: 25
    }
})

export default SignUp