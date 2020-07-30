import React, { useState } from 'react';
import { View, StyleSheet, StatusBar } from 'react-native';
import { Input } from '@ui-kitten/components';
import { colors } from '../variables/colors'
import { Search } from './Icons';

const Filter = (props) => {
        
    const [value, setValue] = React.useState('');

    return (
        <View style={[props.statusBarPadding ? styles.filterContainerStatusBar : styles.filterContainer, { backgroundColor: props.transparent ? colors.transparent : colors.green } ]}>
            <Input
                placeholder='Cuisine, restaurant name...'
                value={value}
                onChangeText={nextValue => setValue(nextValue)}
                icon={Search}
                style={props.transparent && { backgroundColor: colors.transparent }}
            />
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
        justifyContent: 'space-evenly',
        marginTop: 15
    },
    filterButton: {
    }
})

export default Filter