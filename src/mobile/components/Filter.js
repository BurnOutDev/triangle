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
import { debounce } from 'lodash'

const { Navigator, Screen } = createStackNavigator()

const Filter = (props) => {

    const [appeared, setAppeared] = React.useState(false)
    const [value, setValue] = React.useState('');
    const input = React.createRef()

    const Appear = () => {
        setAppeared(true)
    }

    const [data, setData] = React.useState(null)

    const getData = async (text) => {
        if (text) {
            const response = await axios.get('Restaurant/Restaurants', {
                params: {
                    filter: text
                }
            })
            setData(response.data)
        } else {
            setData(null)
        }
    }

    // using "useRef" so that React doesn't create
    // debounced function on each render (after state update).
    const doSearch = React.useRef(
        // using debounce to delay request to backend
        debounce((text) => getData(text), 300)
    ).current

    const Disappear = () => {
        Keyboard.dismiss()
        setAppeared(false)
        setValue('')
        setData(null)
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

        return (
            <View style={{ marginTop: 8 }}>
                <RestaurantList title='Most popular' restaurants={data.restaurants} />
            </View>
        )
    }

    const OnChange = (nextValue) => {
        setValue(nextValue)
        doSearch(nextValue)
    }

    return (
        <View style={appeared && { height: '100%' }}>
            <View style={[props.statusBarPadding ? styles.filterContainerStatusBar : styles.filterContainer, { backgroundColor: props.transparent ? colors.transparent : colors.green },]}>
                <Input
                    placeholder='Cuisine, restaurant name...'
                    value={value}
                    onChangeText={OnChange}
                    icon={appeared ? CloseIcon : SearchIcon}
                    style={styles.text}
                    onFocus={Appear}
                    ref={input}
                />
            </View>

            {data && appeared && <SearchResults />}
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