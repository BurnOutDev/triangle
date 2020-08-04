import React, { useState } from 'react';
import { View, StyleSheet, StatusBar, Keyboard } from 'react-native';
import { Input, Modal, Text, Icon, Button } from '@ui-kitten/components';
import { colors } from '../variables/colors'
import { TouchableWithoutFeedback, ScrollView, TouchableOpacity } from 'react-native-gesture-handler';
import MenuVerticalList from './Menu/MenuVerticalList';
import axios from '../axios';
import { Splash } from '../screens/Screens';
import RestaurantList from './RestaurantList/RestaurantList';
import SingleButton from './SingleButton';
import { material } from 'react-native-typography';
import { createStackNavigator } from '@react-navigation/stack';
import { ClipPath } from 'react-native-svg';

const { Navigator, Screen } = createStackNavigator()

const Filter = (props) => {

    const [appeared, setAppeared] = React.useState(false)
    const [value, setValue] = React.useState('');
    const input = React.createRef()

    const Appear = () => {
        setAppeared(true)
    }

    const [data, setData] = React.useState(null)

    React.useEffect(() => { if (data == null) getData() }, []);

    const getData = async () => {
        const response = await axios.get('Restaurant/Restaurants')

        setData(response.data)
    }

    const Disappear = () => {
        Keyboard.dismiss()
        setAppeared(false)
    }

    const CloseIcon = (style) => (
        <TouchableWithoutFeedback onPress={() => Disappear()}>
            <Icon fill={colors.green} name='close-outline' />
        </TouchableWithoutFeedback>
    )
    const SearchIcon = (style) => (
        <TouchableWithoutFeedback onPress={() => input.current.focus()}>
            <Icon fill={colors.green} name='search-outline' />
        </TouchableWithoutFeedback>
    )

    const SearchResults = (props) => {

        const FilterIcon = (style) => (
            <TouchableOpacity style={styles.filterButtonsContainer} onPress={FilterAppear}>
                <View style={{ flexDirection: 'row', alignItems: 'center' }}>
                    <Icon fill={colors.green} name='funnel-outline' width={24} height={24} />
                    <Text style={styles.filterButton}>Filter</Text>
                </View>
                <Icon fill={colors.green} name='chevron-right' width={24} height={24} />
            </TouchableOpacity>
        )

        const FilterAppear = () => {
            props.navigation.navigate('Filter')
        }

        return (
            <RestaurantList title='Most popular' restaurants={data.restaurants} header={FilterIcon} />
        )
    }

    const FilterContent = (props) => (
        <View style={{ height: '100%', backgroundColor: 'green' }}>

        </View>
    )

    return (
        <View style={appeared && { height: '100%' }}>
            <View style={[props.statusBarPadding ? styles.filterContainerStatusBar : styles.filterContainer, { backgroundColor: props.transparent ? colors.transparent : colors.green },]}>
                <Input
                    placeholder='Cuisine, restaurant name...'
                    value={value}
                    onChangeText={nextValue => setValue(nextValue)}
                    icon={appeared ? CloseIcon : SearchIcon}
                    style={styles.text}
                    onFocus={Appear}
                    ref={input}
                />
            </View>

            {data && appeared && (
                <Navigator screenOptions={{ headerShown: false }} mode='card'>
                    <Screen name='SearchResults' component={SearchResults} />
                    <Screen name='Filter' component={FilterContent} />
                </Navigator>
            )}
        </View>
    )
}

const styles = StyleSheet.create({
    filterContainer: {
        padding: 15,
        paddingTop: 0
    },
    filterContainerStatusBar: {
        padding: 15,
        backgroundColor: colors.green,
        paddingTop: 15 + StatusBar.currentHeight,
    },
    filterButtonsContainer: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        padding: 8
    },
    filterButton: {
        paddingHorizontal: 4
    },
    backdrop: {
        backgroundColor: '#80808080'
    },
    container: {

    },
    text: {
    },
    filterContainerGeneral: {
    }
})

export default Filter