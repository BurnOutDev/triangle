import React from 'react'
import { StyleService, Button } from '@ui-kitten/components'
import { colors } from '../variables/colors'

const SingleButton = ({ style, text, onPress, hasShadow }) => (
    <Button
        style={[styles.singleButton, hasShadow && { ...shadowStyle }, style]}
        textStyle={{ fontWeight: 'normal' }}
        onPress={onPress}>
        {text}
    </Button>
)

const shadowStyle = {
    shadowColor: "#000",
    shadowOffset: {
        width: 0,
        height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 3.84,

    elevation: 5,
}

const styles = StyleService.create({
    singleButton: {
        backgroundColor: colors.green,
        alignSelf: 'center',
        paddingHorizontal: 90,
        height: 40,
        borderRadius: 8,
        borderColor: 'transparent',

        marginVertical: 8
    }
})

export default SingleButton