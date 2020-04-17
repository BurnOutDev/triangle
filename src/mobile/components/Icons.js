import React from 'react'
import { Icon } from "@ui-kitten/components";
import { colors } from '../variables/colors';


export const Search = (style) => (
    <Icon {...style} width='16' height='16' fill={colors.green} name='search' />
)

export const Location = (style) => (
    <Icon {...style} width='16' height='16' fill={colors.green} name='pin-outline' />
)

export const Pin = (style) => (
    <Icon {...style} width='16' height='16' fill={colors.green} name='pin-outline' />
)

export const Heart = (style) => (
    <Icon {...style} width='16' height='16' fill={colors.green} name='heart-outline' />
)

export const Person = (style) => (
    <Icon {...style} width='16' height='16' fill={colors.green} name='person-outline' />
)

export const ArrowRight = (style) => (
    <Icon {...style} width='16' height='16' fill={colors.green} name='chevron-right' />
)

export const Back = (style) => (
    <Icon {...style} width='16' height='16' fill={colors.green} name='arrow-back' />
);

export const Star = (style) => (
    <Icon width='16' height='16' name='star' fill={colors.gold} {...style} />
);