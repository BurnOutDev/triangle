import React from 'react'
import { StyleSheet } from 'react-native'
import { Layout } from '@ui-kitten/components'

const Container = (props) => {

    return (
            <Layout style={styles.layout}>
                {props.children}
            </Layout>
    )
}

const styles = StyleSheet.create({
    layout: {
        
    }
})

export default Container