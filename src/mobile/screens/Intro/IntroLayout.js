import React from 'react';
import { StyleSheet, Dimensions, View, ImageBackground } from 'react-native';
import {
    Layout,
    Text,
    ViewPager,
    Button,
    Icon
} from '@ui-kitten/components';

const PrevIcon = (style) => (
    <Icon {...style} name='arrow-ios-back-outline' />
);

const NextIcon = (style) => (
    <Icon {...style} name='arrow-ios-forward-outline' />
);

const Next = (props) => <Button icon={NextIcon} onPress={props.onPress} appearance='ghost' status='primary' style={{ ...styles.button, flexDirection: 'row-reverse' }}>Next</Button>
const Prev = (props) => <Button icon={PrevIcon} onPress={props.onPress} appearance='ghost' status='primary' style={styles.button}>Prev</Button>
const Finish = (props) => <Button icon={NextIcon} onPress={props.onPress} appearance='ghost' status='primary' style={{ ...styles.button, flexDirection: 'row-reverse' }}>Finish</Button>

const IntroLayout = () => {

    const [selectedIndex, setSelectedIndex] = React.useState(0);

    const onNext = () => {
        setSelectedIndex(selectedIndex + 1)
    }

    const onPrev = () => {
        setSelectedIndex(selectedIndex - 1)
    }

    const onFinish = () => {

    }

    return (
        <ViewPager selectedIndex={selectedIndex} onSelect={setSelectedIndex}>
            <Layout level='2' style={styles.tab}>
                <ImageBackground resizeMode='cover' source={require('../../assets/background.jpg')} style={styles.imageBg}>
                    <View style={styles.contentContainer}>
                        <View style={{ alignSelf: 'flex-start' }}>
                            <Text style={styles.title} category='h1'>Discover</Text>
                            <Text style={styles.description} category='s2'>Search the top rated restaurants nearby yoour area.</Text>
                            <Button style={styles.getStarted} status='basic'>Get started</Button>
                        </View>
                        <View style={{ ...styles.buttonsContainer, justifyContent: 'flex-end' }}>
                            <Next onPress={onNext} />
                        </View>
                    </View>
                </ImageBackground>
            </Layout>
            <Layout level='2' style={styles.tab}>
                <ImageBackground resizeMode='cover' source={require('../../assets/background.jpg')} style={styles.imageBg}>
                    <View style={styles.contentContainer}>
                        <View style={{ alignSelf: 'flex-start' }}>
                            <Text style={styles.title} category='h1'>Book a table</Text>
                            <Text style={styles.description} category='s2'>Reserve or modify your reservation anytime, anywhere.</Text>
                            <Button style={styles.getStarted} status='basic'>Get started</Button>
                        </View>
                        <View style={{ ...styles.buttonsContainer, justifyContent: 'flex-end' }}>
                            <Prev onPress={onPrev} />
                            <Next onPress={onNext} />
                        </View>
                    </View>
                </ImageBackground>
            </Layout>
            <Layout level='2' style={styles.tab}>
                <ImageBackground resizeMode='cover' source={require('../../assets/background.jpg')} style={styles.imageBg}>
                    <View style={styles.contentContainer}>
                        <View style={{ alignSelf: 'flex-start' }}>
                            <Text style={styles.title} category='h1'>Special offers</Text>
                            <Text style={styles.description} category='s2'>Find and get special offers from your favorite restaurants.</Text>
                            <Button style={styles.getStarted} status='basic'>Get started</Button>
                        </View>
                        <View style={{ ...styles.buttonsContainer, justifyContent: 'flex-end' }}>
                            <Finish onPress={onFinish} />
                        </View>
                    </View>
                </ImageBackground>
            </Layout>
        </ViewPager>
    );
};

const styles = StyleSheet.create({
    tab: {
        height: Dimensions.get('window').height
    },
    buttonsContainer: {
        display: 'flex',
        flexDirection: 'row',
        justifyContent: 'space-between'
    },
    contentContainer: {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'flex-end',
        // backgroundColor: 'white',
        height: Dimensions.get('window').height,
        padding: 30
    },
    title: {
        textAlign: 'center',
        color: 'white',
        marginBottom: 10
    },
    description: {
        textAlign: 'center',
        color: 'white',
        marginBottom: 45,
        paddingLeft: 45,
        paddingRight: 45
    },
    imageBg: {
        flex: 1,
        resizeMode: 'cover',
    },
    getStarted: {
        marginBottom: 25
    }
});

export default IntroLayout;