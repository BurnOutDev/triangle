import React, { useState } from 'react';
import { View, StyleSheet, StatusBar } from 'react-native';
import { Input } from '@ui-kitten/components';
import { colors } from '../variables/colors'
import { Search } from './Icons';

const Filter = () => {
    const [value, setValue] = React.useState('');

    return (
        <View style={styles.filterContainer}>
            <Input
                size='small'
                placeholder='Cuisine, restaurant name...'
                value={value}
                onChangeText={nextValue => setValue(nextValue)}
                icon={Search}
            />
        </View>
    )
}

const styles = StyleSheet.create({
    filterContainer: {
        padding: 15,
        paddingTop: 15 + StatusBar.currentHeight,
        backgroundColor: colors.green,
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